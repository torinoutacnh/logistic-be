using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
{
    public class UpdateCarPriceModel
    {
        public Guid Id { get; set; }
        public decimal ShipPrice { get; set; }
        public decimal TravelPrice { get; set; }

        public UpdateCarPriceModel(Guid id, decimal shipPrice, decimal travelPrice)
        {
            Id = id;
            ShipPrice = shipPrice;
            TravelPrice = travelPrice;
        }
    }
}
