using eShopSolution.Utilities.Constant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace eShopSolution.Data.EF
{
    public class EShopSolutionDbContextFactory : IDesignTimeDbContextFactory<EShopDbContext>
    {
        public EShopDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectString = config.GetConnectionString(SystemConstant.MainConnectString);

            var opBuilder = new DbContextOptionsBuilder<EShopDbContext>();
            opBuilder.UseSqlServer(connectString);

            return new EShopDbContext(opBuilder.Options);
        }
    }
}