using FU.Domain.Entities.Car;

namespace FU.Service.Models.Car
{
    public class CarMapModel
    {
        public decimal ShipPrice { get; set; }
        public decimal TravelPrice { get; set; }

        public string CarModel { get;  set; }
        public string CarColor { get;  set; }
        public string ImagePath { get;  set; }
        public string Tel { get;  set; }
        public string CarNumber { get;  set; }
        public CarServiceType ServiceType { get;  set; }

        public Guid CarsManagerId { get; set; }

        public ICollection<SeatInfoModel>? Seats { get;  set; }
        public ICollection<StopPointInfoModel>? StopPoints { get; set; }
        public ICollection<RouteInfoModel>? Routes { get; set; }
    }
}
