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
        public Guid FromId { get; private set; }
        public Guid ToId { get; private set; }

        public decimal DistanceByKm { get; private set; }
        public decimal Day { get; private set; }
        public decimal Hour { get; private set; }
        public decimal Minute { get; private set; }

        public DateTimeOffset DailyStartTime { get; private set; }

        public RouteModel(Guid id, Guid carId, Guid fromId, Guid toId, decimal distanceByKm, decimal day, decimal hour, decimal minute, DateTimeOffset dailyStartTime)
        {
            Id = id;
            CarId = carId;
            FromId = fromId;
            ToId = toId;
            DistanceByKm = distanceByKm;
            Day = day;
            Hour = hour;
            Minute = minute;
            DailyStartTime = dailyStartTime;
        }

        public RouteModel(RouteEntity entity)
        {
            Id = entity.Id;
            CarId = entity.CarId;
            FromId = entity.FromId;
            ToId = entity.ToId;
            DistanceByKm = entity.DistanceByKm;
            Day = entity.Day;
            Hour = entity.Hour;
            Minute = entity.Minute;
            DailyStartTime = entity.DailyStartTime;
        }
    }
}
