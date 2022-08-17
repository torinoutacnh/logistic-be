using FU.Infras.CustomAttribute;
using FU.Repository.Extension;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Extension
{
    public static class RegisterService
    {
        public static IServiceCollection AddServices(this IServiceCollection @this)
        {
            var types = from type in typeof(RegisterService).Assembly.GetTypes()
                        where !type.IsInterface
                        select type;
            var interfaces = from type in typeof(RegisterService).Assembly.GetTypes()
                             where type.IsInterface
                             select type;
            foreach (var interfacesType in interfaces)
            {
                var member = types.FirstOrDefault(p => interfacesType.IsAssignableFrom(p));
                if (member != null)
                {
                    var registerTypes = member.GetCustomAttributes();
                    if (registerTypes.Where(x => x.GetType() == typeof(RegisterSingletonAttribute)).Any())
                    {
                        @this.AddSingleton(interfacesType, member);
                        continue;
                    }
                    if (registerTypes.Where(x => x.GetType() == typeof(RegisterScopeAttribute)).Any())
                    {
                        @this.AddScoped(interfacesType, member);
                        continue;
                    }
                    if (registerTypes.Where(x => x.GetType() == typeof(RegisterTransientAttribute)).Any())
                    {
                        @this.AddTransient(interfacesType, member);
                        continue;
                    }
                }
            }
            return @this;
        }
    }
}
