using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
{
    public class UpdateCarRouteModel
    {
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        public decimal DistanceByKm { get; private set; }
        public decimal Day { get; private set; }
        public decimal Hour { get; private set; }
        public decimal Minute { get; private set; }

        public UpdateCarRouteModel(Guid fromId, Guid toId, decimal distanceByKm, decimal day, decimal hour, decimal minute)
        {
            FromId = fromId;
            ToId = toId;
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
        }
    }
}
