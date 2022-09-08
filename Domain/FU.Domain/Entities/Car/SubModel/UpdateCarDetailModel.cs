using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
{
    public class UpdateCarDetailModel
    {
        public Guid Id { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string ImagePath { get; set; }
        public string Tel { get; set; }
        public string CarNumber { get; set; }
        public CarServiceType ServiceType { get; set; }

        public UpdateCarDetailModel(Guid id, string carModel, string carColor, string imagePath, string tel, string carNumber, CarServiceType serviceType)
        {
            Id = id;
            CarModel = carModel;
            CarColor = carColor;
            ImagePath = imagePath;
            Tel = tel;
            CarNumber = carNumber;
            ServiceType = serviceType;
        }
    }
}
