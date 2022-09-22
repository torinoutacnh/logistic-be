using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route.SubModel
{
    public class UpdateCarRouteModel
    {
        public Location From { get; set; }
        public Location To { get; set; }

        public decimal DistanceByKm { get; private set; }
        public decimal Day { get; private set; }
        public decimal Hour { get; private set; }
        public decimal Minute { get; private set; }

        public UpdateCarRouteModel(Location from, Location to, decimal distanceByKm, decimal day, decimal hour, decimal minute)
        {
            From = from;
            To = to;
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
        }
    }
}
