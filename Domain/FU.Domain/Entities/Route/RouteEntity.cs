using FU.Domain.Base;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.StopPoint;
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
        public Guid FromId { get; private set; }
        public Guid ToId { get; private set; }

        public decimal DistanceByKm { get; private set; }
        public decimal Day { get; private set; }
        public decimal Hour { get; private set; }
        public decimal Minute { get; private set; }

        public DateTimeOffset DailyStartTime { get; private set; }

        public virtual CarEntity? Car { get; }
        public virtual StopPointEntity? FromPoint { get; }
        public virtual StopPointEntity? ToPoint { get; }

        private RouteEntity() { }

        public RouteEntity(Guid carId, Guid fromId, Guid toId, decimal distanceByKm, decimal day,decimal hour, decimal minute, DateTimeOffset dailyStartTime)
        {
            CarId = carId;
            FromId = fromId;
            ToId = toId;
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
            DailyStartTime = dailyStartTime;
        }

        public void Update(Guid fromId, Guid toId, decimal distanceByKm, decimal day, decimal hour, decimal minute, DateTimeOffset dailyStartTime)
        {
            FromId = fromId;
            ToId = toId;
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
            DailyStartTime= dailyStartTime;
        }
    }
}
