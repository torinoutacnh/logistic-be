using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarRouteMapping.SubModel
{
    public class UpdateCarRouteMappingStarttimeModel
    {
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTimeOffset Starttime { get; private set; }

        public UpdateCarRouteMappingStarttimeModel(Guid carId, Guid routeId, DateTimeOffset starttime)
        {
            CarId = carId;
            RouteId = routeId;
            Starttime = starttime;
        }
    }
}
