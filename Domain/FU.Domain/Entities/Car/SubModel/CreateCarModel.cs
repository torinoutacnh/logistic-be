using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
{
    public class CreateCarModel
    {
        public decimal ShipPrice { get; set; }
        public decimal TravelPrice { get; set; }
        public string CarModel { get;  set; }
        public string CarColor { get;  set; }
        public string ImagePath { get;  set; }
        public string Tel { get;  set; }
        public string CarNumber { get;  set; }
        public CarServiceType ServiceType { get;  set; }

        public Guid? CarsManagerId { get;  set; }

        public CreateCarModel(decimal shipPrice, decimal travelPrice, string carModel, string carColor, string imagePath, string tel, string carNumber, CarServiceType serviceType, Guid? carsManagerId = null)
        {
            ShipPrice = shipPrice;
            TravelPrice = travelPrice;
            CarModel = carModel;
            CarColor = carColor;
            ImagePath = imagePath;
            Tel = tel;
            CarNumber = carNumber;
            ServiceType = serviceType;
            CarsManagerId = carsManagerId;
        }
    }
}
