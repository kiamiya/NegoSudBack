using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.dbContext;

namespace DataAccess.DbContextFactory
{
    internal class NegoSudDBContextFactory : IDesignTimeDbContextFactory<NegoSudDBContext>
    {
        IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        public NegoSudDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NegoSudDBContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("wmgDb"), b => b.MigrationsAssembly("DataAccess"));

            return new NegoSudDBContext(optionsBuilder.Options);
        }
    }
}
