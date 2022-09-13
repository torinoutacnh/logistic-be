using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarsManager.SubModel
{
    public class CarsManagerViewModel
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? LogoPath { get; private set; }

        public CarsManagerViewModel(CarsManagerEntity carsManager)
        {
            Name = carsManager.Name;
            Description = carsManager.Description;
            LogoPath = carsManager.LogoPath;
        }
    }
}
