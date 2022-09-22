using FU.Domain.Base;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Mapping
{
    public class CarRouteMappingEntity:Entity
    {
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTimeOffset Starttime { get; private set; }
        public virtual CarEntity? Car { get; private set; }
        public virtual RouteEntity? Route { get; private set; }

        private CarRouteMappingEntity() { }

        public CarRouteMappingEntity(Guid carId, Guid routeId, DateTimeOffset starttime)
        {
            CarId = carId;
            RouteId = routeId;
            Starttime = starttime;
        }
    }
}
