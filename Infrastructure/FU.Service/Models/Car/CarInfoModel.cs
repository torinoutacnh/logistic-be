using FU.Domain.Entities.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Models.Car
{
    public class CarInfoModel
    {
        public Guid Id { get; set; }
        public decimal ShipPrice { get; set; }
        public decimal TravelPrice { get; set; }

        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string ImagePath { get; set; }
        public string Tel { get; set; }
        public string CarNumber { get; set; }
        public CarServiceType ServiceType { get; set; }
    }
}
