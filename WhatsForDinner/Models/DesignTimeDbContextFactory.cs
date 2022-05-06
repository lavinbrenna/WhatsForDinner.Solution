using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WhatsForDinner.Models
{
  public class WhatsForDinnerContextFactory : IDesignTimeDbContextFactory <WhatsForDinnerContext>
  {
    WhatsForDinnerContext IDesignTimeDbContextFactory<WhatsForDinnerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        var builder = new DbContextOptionsBuilder<WhatsForDinnerContext>();

        builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

        return new WhatsForDinnerContext(builder.Options);
    }
  }
}