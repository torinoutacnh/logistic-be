using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarRouteMapping.SubModel
{
    public class CreateCarRouteMappingStarttimeModel
    {
        public Guid CarId { get;  set; }
        public Guid RouteId { get;  set; }
        public DateTimeOffset Starttime { get;  set; }
        
    }
}
