using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route.SubModel
{
    public class CreateCarRouteModel
    {
        public Location From { get; private set; }
        public Location To { get; private set; }

        public decimal DistanceByKm { get; private set; }
        public decimal Day { get; private set; }
        public decimal Hour { get; private set; }
        public decimal Minute { get; private set; }

        public CreateCarRouteModel(Location from, Location to, decimal distanceByKm, decimal day, decimal hour, decimal minute)
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
