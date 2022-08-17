using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public string ApplicationName { get; set; } = Assembly.GetEntryAssembly()?.GetName().Name;
        public string Version { get; set; }
        public string Domain { get; set; } = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        public string Host { get; set; } = System.Net.Dns.GetHostName();
    }

    public static class SystemHelper
    {
        public static SystemHelperModel Setting => SystemHelperModel.Instance;
        public static IConfiguration Configs => SystemHelperModel.Configs;
        public static string AppDb => SystemHelperModel.Configs.GetConnectionString("Default");

        public static DateTimeOffset SystemTimeNow => DateTimeOffset.UtcNow;
    }

    public static class SystemSetingExtension
    {
        public static IServiceCollection AddSystemSetting(this IServiceCollection services, SystemHelperModel systemSettingModel)
        {
            SystemHelperModel.Instance = systemSettingModel ?? throw new ArgumentNullException(nameof(systemSettingModel));
            return services;
        }

        public static IApplicationBuilder UseSystemSetting(this IApplicationBuilder app)
        {
            SystemHelperModel.Configs = app.ApplicationServices.GetRequiredService<IConfiguration>();

            return app;
        }
    }
}
