using FU.Domain.Base;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.Mapping;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.Seat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car
{
    public class CarEntity:Entity
    {
        public decimal ShipPrice { get; private set; }
        public decimal TravelPrice { get; private set; }

        public string CarModel { get;private set; }
        public string CarColor { get;private set; }
        public string ImagePath { get;private set; }
        public string Tel { get;private set; }
        public string CarNumber { get; private set; }
        public CarServiceType ServiceType { get; private set; }

        public Guid? CarsManagerId { get;private set; }

        public Guid? RouteId { get;private set; }

        public virtual CarsManagerEntity? CarsManager { get; }
        public virtual ICollection<SeatEntity>? Seats { get; }
        public virtual ICollection<Mapping.CarRouteMappingEntity>? CarRouteMappings { get; }
        
        private CarEntity() { }

        public CarEntity(decimal shipPrice,decimal travelPrice,string carModel, string carColor, string imagePath, string tel,string carNumber, CarServiceType carServiceType, Guid? carsManagerId = null)
        {
            ShipPrice = shipPrice;
            TravelPrice = travelPrice;
            CarModel = carModel ?? throw new ArgumentNullException(nameof(carModel));
            CarColor = carColor ?? throw new ArgumentNullException(nameof(carColor));
            ImagePath = imagePath ?? throw new ArgumentNullException(nameof(imagePath));
            Tel = tel ?? throw new ArgumentNullException(nameof(tel));
            CarNumber = carNumber ?? throw new ArgumentNullException(nameof(carNumber));
            ServiceType = carServiceType;
            CarsManagerId = carsManagerId;
            Seats = new HashSet<SeatEntity>();
        }

        public void UpdatePrice(decimal shipPrice, decimal travelPrice)
        {
            ShipPrice = shipPrice;
            TravelPrice = travelPrice;
        }

        public void UpdateCarDetail(string carModel, string carColor, string imagePath, string tel, string carNumber, CarServiceType carServiceType)
        {
            CarModel = carModel ?? throw new ArgumentNullException(nameof(carModel));
            CarColor = carColor ?? throw new ArgumentNullException(nameof(carColor));
            ImagePath = string.IsNullOrEmpty(imagePath) ? ImagePath : imagePath;
            Tel = tel ?? throw new ArgumentNullException(nameof(tel));
            CarNumber = carNumber ?? throw new ArgumentNullException(nameof(carNumber));
            ServiceType = carServiceType;
        }
    }
}
