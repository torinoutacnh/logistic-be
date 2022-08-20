using FU.Infras.Application;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Infras.Loging
{
    public static class SerilogExtension
    {
        public static IServiceCollection AddCustomLog(this IServiceCollection @this,LogEventLevel loglevel, RollingInterval rollingInterval)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(loglevel)
                .WriteTo
                .File($"logs/Log.log", rollingInterval: rollingInterval)
                .CreateLogger();
            @this.AddSingleton<ILogger>(Log.Logger);
            return @this;
        }
    }
}
