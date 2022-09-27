using FU.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarRouteMapping.SubModel
{
    public class CarRouteMappingInfoModel
    {
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public DateTimeOffset Starttime { get; private set; }

        public CarRouteMappingInfoModel(Mapping.CarRouteMappingEntity carRouteMappingEntity)
        {
            CarId = carRouteMappingEntity.CarId;
            RouteId = carRouteMappingEntity.RouteId;
            Starttime = carRouteMappingEntity.Starttime;
        }
        public CarRouteMappingInfoModel(Guid CarId, Guid RouteId, DateTimeOffset Starttime)
        {
            this.CarId = CarId;
            this.RouteId = RouteId;
            this.Starttime = Starttime;
        }
    }
}
