using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace Restrike.GitHubIntegration.PostgresInstall
{
    internal class WaitDatabaseAction : IDatabaseAction
    {
        private string connectionString = "";
        private string masterConnectionString = "";

        private const string PARAMKEYS_CREATE = "create";
        private const string PARAMKEYS_MASTERDB = "masterdb";
        int IDatabaseAction.SortOrder { get => 1; }

        private bool MasterDbAvailable()
        {
            var retVal = false;
            for (var ii = 1; ii < 21; ii++)
            {
                if (DatabaseServer.TestConnectionString(masterConnectionString))
                {
                    retVal = true;
                    break;
                }
                Log.Information($"Unable to connect to postgress attempt {ii.ToString()} of 20");
                System.Threading.Thread.Sleep(10000);
            }
            return retVal;
        }

        private bool DbAvailable()
        {
            var retVal = false;
            for (var ii = 1; ii < 21; ii++)
            {
                if (DatabaseServer.TestConnectionString(connectionString))
                {
                    retVal = true;
                    break;
                }
                Log.Information($"Unable to connect to postgress attempt {ii.ToString()} of 20");
                System.Threading.Thread.Sleep(10000);
            }
            return retVal;
        }

        void IDatabaseAction.Execute(Dictionary<string, string> input)
        {
            if (input.Any(x => x.Key == PARAMKEYS_CREATE))
            {
                masterConnectionString = DatabaseInstaller.GetSetting(input, PARAMKEYS_MASTERDB, string.Empty);
                if (!MasterDbAvailable())
                    throw new Exception("Master Db Not Available");
            }
            else
            {
                connectionString = DatabaseInstaller.GetSetting(input, DatabaseInstaller.PARAMKEYS_APPDB, string.Empty);
                if (!DbAvailable())
                    throw new Exception("Database Not Available");

            }
        }
    }
}
