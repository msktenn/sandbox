using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace Restrike.GitHubIntegration.PostgresInstall
{
    internal class CreateDatabaseAction : IDatabaseAction
    {
        private string connectionString = "";
        private string newDatabaseName = "";
        private string masterConnectionString = "";

        private const string PARAMKEYS_CREATE = "create";
        private const string PARAMKEYS_MASTERDB = "masterdb";
        private const string PARAMKEYS_NEWNAME = "newdatabase";

        int IDatabaseAction.SortOrder { get => 2; }

        public void Execute(Dictionary<string, string> input)
        {
            if (!input.Any(x => x.Key == PARAMKEYS_CREATE))
                return;

            connectionString = DatabaseInstaller.GetSetting(input, DatabaseInstaller.PARAMKEYS_APPDB, string.Empty);
            Log.Information($"connectionstring censored: {CensorConnectionString(connectionString)}");
            masterConnectionString = DatabaseInstaller.GetSetting(input, PARAMKEYS_MASTERDB, string.Empty);
            Log.Information($"masterconnectionstring censored: {CensorConnectionString(masterConnectionString)}");
            newDatabaseName = DatabaseInstaller.GetSetting(input, PARAMKEYS_NEWNAME, string.Empty);
            Log.Information($"newDatabaseName: {newDatabaseName}");

            if (DatabaseServer.TestConnectionString(connectionString))
                throw new Exception("The connection string references an existing database.");

            if (string.IsNullOrEmpty(newDatabaseName))
                throw new Exception("A new database name was not specified.");

            var builder = new Npgsql.NpgsqlConnectionStringBuilder(connectionString);
            if (builder.Database.ToLower() != newDatabaseName.ToLower())
                throw new Exception("A new database name does not match the specified connection string.");

            CreateDatabase();
        }

        private static string CensorConnectionString(string connectionString)
        {
            try
            {
                var keyValues = connectionString.Split(';');
                var listToKeep = new List<string>();
                foreach (var keyValue in keyValues)
                {
                    var key = keyValue.Split('=')[0].Trim();
                    if (key.ToLower() != "password" && key.ToLower() != "pwd")
                        listToKeep.Add(keyValue);
                    else
                        listToKeep.Add("********");
                }
                var safeConnectionStringForLog = string.Join(";", listToKeep.ToArray());
                return safeConnectionStringForLog;
            }
            catch (Exception ex)
            {
                return connectionString;
            }
        }


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


        private void CreateDatabase()
        {
            try
            {
                using (var conn = new NpgsqlConnection(masterConnectionString))
                {
                    conn.Open();
                    var cmdCreateDb = new NpgsqlCommand();
                    var fileInfo = string.Empty;
                    cmdCreateDb.CommandText = $"CREATE DATABASE \"{newDatabaseName}\"";
                    cmdCreateDb.CommandType = System.Data.CommandType.Text;
                    cmdCreateDb.Connection = conn;
                    DatabaseServer.ExecuteCommand(cmdCreateDb);
                }

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    //Add UUID generator
                    var command = new NpgsqlCommand();
                    command.CommandText = "CREATE EXTENSION \"uuid-ossp\";";
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = conn;
                    DatabaseServer.ExecuteCommand(command);
                }
            }
            catch { throw; }
            finally
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        void IDatabaseAction.Execute(Dictionary<string, string> input)
        {
            this.Execute(input);
        }
    }
}
