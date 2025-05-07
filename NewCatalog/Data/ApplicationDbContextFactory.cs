using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NewCatalog.Data;
using System.IO;

namespace NewCatalog
{
    //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

    //        // Отримуємо налаштування для підключення до бази даних із файлу конфігурації
    //        var configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

    //        return new ApplicationDbContext(optionsBuilder.Options);
    //    }
    //}
}
