using FU.Domain.Base;
using FU.Infras.CustomAttribute;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Extension
{
    public static class RegisterRepository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection @this)
        {
            var types = from type in typeof(RegisterRepository).Assembly.GetTypes()
                        where !type.IsInterface
                        select type;
            var interfaces = from type in typeof(Entity).Assembly.GetTypes()
                        where type.IsInterface && type.IsGenericType == false
                        select type;
            foreach(var interfacesType in interfaces)
            {
                var member = types.FirstOrDefault(p => interfacesType.IsAssignableFrom(p));
                if(member != null)
                {
                    var registerTypes = member.GetCustomAttributes();
                    if (registerTypes.Where(x => x.GetType() == typeof(RegisterSingletonAttribute)).Any())
                    {
                        @this.AddSingleton(interfacesType,member);
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
