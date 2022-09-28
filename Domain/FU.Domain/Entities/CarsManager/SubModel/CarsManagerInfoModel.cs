using FU.Domain.Entities.Car.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarsManager.SubModel
{
    public class CarsManagerInfoModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? LogoPath { get; private set; }

        public ICollection<CarViewModel> Cars { get; set; }

        public CarsManagerInfoModel(CarsManagerEntity carsManager)
        {
            Id = carsManager.Id;
            Name = carsManager.Name;
            Description = carsManager.Description;
            LogoPath = carsManager.LogoPath;

            Cars = carsManager.Cars?.Select(x => new CarViewModel(x)).ToList() ?? new List<CarViewModel>();
        }
    }
}
