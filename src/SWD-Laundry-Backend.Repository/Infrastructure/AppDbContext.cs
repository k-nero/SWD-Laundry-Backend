﻿using System.Reflection;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SWD_Laundry_Backend.Core.Utils;
using SWD_Laundry_Backend.Repository.Base;

namespace SWD_Laundry_Backend.Repository.Infrastructure;
//[ScopedDependency(ServiceType = typeof(AppDbContext))]
public sealed partial class AppDbContext : BaseDbContext
{
    public readonly int CommandTimeoutInSecond = 20 * 60;

    public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(
            builder => builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole());

    public AppDbContext(DbContextOptions options) : base(options)
    {
        Database.SetCommandTimeout(CommandTimeoutInSecond);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            /*  var configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.Development.json")
                  .Build();
              var connectionString = configuration.GetConnectionString("DefaultConnection");*/

            var connectionString = SystemHelper.AppDb;
            //var connectionString = "Data Source=(local);Initial Catalog=WaterCity-Portal;user=sa;pwd=12345;Trusted_Connection=True;Trust Server Certificate=True";

            optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.MigrationsAssembly(
                    typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);

                sqlServerOptionsAction.MigrationsHistoryTable("Migration");
            });
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
