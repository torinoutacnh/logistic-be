using FU.Domain.Entities.Car;

namespace API.Models.Car
{
    public class CarMapModel
    {
        public decimal ShipPrice { get; set; }
        public decimal TravelPrice { get; set; }

        public string CarModel { get; private set; }
        public string CarColor { get; private set; }
        public string ImagePath { get; private set; }
        public string Tel { get; private set; }
        public string CarNumber { get; private set; }
        public CarServiceType ServiceType { get; private set; }
    }
}
