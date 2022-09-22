using FU.Domain.Base;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route
{
    public class RouteEntity:Entity
    {
        public Guid CarId { get; private set; }
        public Location From { get; private set; }
        public Location To { get; private set; }

        public decimal DistanceByKm { get; private set; }
        public decimal Day { get; private set; }
        public decimal Hour { get; private set; }
        public decimal Minute { get; private set; }

        public DateTimeOffset DailyStartTime { get; private set; }

        public virtual CarEntity? Car { get; }
        public virtual ICollection<CarRouteMappingEntity>? CarRouteMappings { get; }
        private RouteEntity() { }

        public RouteEntity(Guid carId, Location from, Location to, decimal distanceByKm, decimal day,decimal hour, decimal minute, DateTimeOffset dailyStartTime)
        {
            CarId = carId;
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
            DailyStartTime = dailyStartTime;
        }

        public void Update(Location from, Location to, decimal distanceByKm, decimal day, decimal hour, decimal minute, DateTimeOffset dailyStartTime)
        {
            From = from;
            To = to;
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
            DailyStartTime= dailyStartTime;
        }
    }
}
