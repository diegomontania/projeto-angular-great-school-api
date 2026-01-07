using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GreatSchool.Infrastructure.Data
{
    public class GreatSchoolDBContextFactory : IDesignTimeDbContextFactory<GreatSchoolDBContext>
    {
        public GreatSchoolDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GreatSchool.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GreatSchoolDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GreatSchoolDB"));

            return new GreatSchoolDBContext(optionsBuilder.Options);
        }
    }
}