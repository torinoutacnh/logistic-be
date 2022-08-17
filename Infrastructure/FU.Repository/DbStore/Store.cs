﻿using FU.Repository.DbStore.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace FU.Repository.DbStore
{
    public partial class Store : DbContext
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(
            builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });
        public readonly int CommandTimeoutInSecond = 20 * 60;

        public Store()
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        public Store(DbContextOptions<Store> options) : base(options)
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(isDevelopment ? "appsettings.Development.json": "appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly("API");

                    sqlServerOptionsAction.MigrationsHistoryTable("Migration");

                    sqlServerOptionsAction.EnableRetryOnFailure(maxRetryCount:4,maxRetryDelay:TimeSpan.FromSeconds(1),errorNumbersToAdd: Array.Empty<int>());
                });

                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                optionsBuilder.UseLoggerFactory(LoggerFactory);

                
                if (isDevelopment)
                {
                    optionsBuilder.EnableDetailedErrors();
                    optionsBuilder.EnableSensitiveDataLogging();
                    optionsBuilder.ConfigureWarnings(warningAction =>
                    {
                        warningAction.Log(new EventId[]
                        {
                            CoreEventId.FirstWithoutOrderByAndFilterWarning,
                            CoreEventId.RowLimitingOperationWithoutOrderByWarning,
                        });
                    });
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FormConfig());
            modelBuilder.ApplyConfiguration(new FormAttributeConfig());
        }
    }
}
