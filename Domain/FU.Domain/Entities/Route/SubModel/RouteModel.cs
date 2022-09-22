using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route.SubModel
{
    public class RouteModel
    {
        public Guid Id { get; private set; }
        public Guid CarId { get; private set; }
        public LocationInfo From { get; private set; }
        public LocationInfo To { get; private set; }

        public decimal DistanceByKm { get; private set; }
        public decimal Day { get; private set; }
        public decimal Hour { get; private set; }
        public decimal Minute { get; private set; }

        public DateTimeOffset DailyStartTime { get; private set; }

        public RouteModel(Guid id, Guid carId, LocationInfo from, LocationInfo to, decimal distanceByKm, decimal day, decimal hour, decimal minute, DateTimeOffset dailyStartTime)
        {
            Id = id;
            CarId = carId;
            From = from;
            To = to;
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
            DailyStartTime = dailyStartTime;
        }
    }
}
