using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using FU.Domain.Entities.StopPoint.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
{
    public class CarInfoModel
    {
        public decimal ShipPrice { get; private set; }
        public decimal TravelPrice { get; private set; }

        public string CarModel { get; private set; }
        public string CarColor { get; private set; }
        public string ImagePath { get; private set; }
        public string Tel { get; private set; }
        public string CarNumber { get; private set; }
        public CarServiceType ServiceType { get; private set; }

        public Guid? CarsManagerId { get; private set; }

        public IEnumerable<SeatModel> Seats { get; private set; }
        public IEnumerable<RouteModel> Routes { get; private set; }
        public IEnumerable<StopPointModel> StopPoints { get; private set; }

        public CarInfoModel(CarEntity car, IEnumerable<SeatModel> seats, IEnumerable<RouteModel> routes, IEnumerable<StopPointModel> stopPoints)
        {
            ShipPrice = car.ShipPrice;
            TravelPrice = car.TravelPrice;
            CarModel = car.CarModel;
            CarColor = car.CarColor;
            ImagePath = car.ImagePath;
            Tel = car.Tel;
            CarNumber = car.CarNumber;
            ServiceType = car.ServiceType;
            CarsManagerId = car.CarsManagerId;
            Seats = seats;
            Routes = routes;
            StopPoints = stopPoints;
        }
    }
}
