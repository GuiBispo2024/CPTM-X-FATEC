using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class AppDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(
        string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "../Backend.API"
                )
            )
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>();

        var connectionString =
            configuration.GetConnectionString("OracleDb");

        optionsBuilder.UseOracle(
            connectionString
        );

        return new AppDbContext(
            optionsBuilder.Options
        );
    }
}