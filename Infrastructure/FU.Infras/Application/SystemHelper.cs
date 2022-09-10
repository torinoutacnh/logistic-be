using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FU.Infras.Application
{
    public class SystemHelperModel
    {
        public static SystemHelperModel Instance { get; set; }
        public static IConfiguration Configs { get; set; }
        public string Version { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Debug;
        public LogEventLevel SeriLogLevel { get; set; } = LogEventLevel.Debug;
        public RollingInterval SeriLogInterval { get; set; } = RollingInterval.Day;
        public string ApiName { get; set; } = "Default";
    }

    public static class SystemHelper
    {
        public static SystemHelperModel Setting => SystemHelperModel.Instance;
        public static IConfiguration Configs => SystemHelperModel.Configs;
        public static string? ApplicationName => Assembly.GetEntryAssembly()?.GetName().Name;
        public static string Domain => System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        public static string Host => System.Net.Dns.GetHostName();
        public static string AppDb => SystemHelperModel.Configs.GetConnectionString("DefaultConnection");

        public static DateTimeOffset SystemTimeNow => DateTimeOffset.UtcNow;
        public static DateTimeOffset LastestDepoyTime = DateTimeOffset.Now;
    }

    public static class SystemSetingExtension
    {
        public static IServiceCollection AddSystemSetting(this IServiceCollection services, SystemHelperModel systemSettingModel)
        {
            SystemHelperModel.Instance = systemSettingModel ?? new SystemHelperModel();

            return services;
        }

        public static IApplicationBuilder UseSystemSetting(this IApplicationBuilder app)
        {
            SystemHelperModel.Configs = app.ApplicationServices.GetRequiredService<IConfiguration>();

            return app;
        }
    }
}
