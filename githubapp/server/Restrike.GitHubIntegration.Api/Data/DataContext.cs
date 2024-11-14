using Microsoft.EntityFrameworkCore;
using Restrike.GitHubIntegration.Api.Models;

namespace Restrike.GitHubIntegration.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Configuration> Configurations { get; set; }
    }
}