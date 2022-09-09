using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.AutoMapperProfile
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapperProfileExt(this IServiceCollection @this)
        {
            @this.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CarsManagerProfile>();
                cfg.AddProfile<CarProfile>();
            });

            return @this;
        }
    }
}
