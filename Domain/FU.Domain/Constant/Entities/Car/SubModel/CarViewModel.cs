using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
{
    public class CarViewModel
    {
        public Guid Id { get; private set; }
        public decimal ShipPrice { get; private set; }
        public decimal TravelPrice { get; private set; }

        public string CarModel { get; private set; }
        public string CarColor { get; private set; }
        public string ImagePath { get; private set; }
        public string Tel { get; private set; }
        public string CarNumber { get; private set; }
        public string? CarsManagerName { get; private set; }
        public CarServiceType ServiceType { get; private set; }

        public CarViewModel(CarEntity car)
        {
            Id = car.Id;
            ShipPrice = car.ShipPrice;
            TravelPrice = car.TravelPrice;
            CarModel = car.CarModel;
            CarColor = car.CarColor;
            ImagePath = car.ImagePath;
            Tel = car.Tel;
            CarNumber = car.CarNumber;
            ServiceType = car.ServiceType;
            CarsManagerName = car.CarsManager?.Name;
        }
    }
}
