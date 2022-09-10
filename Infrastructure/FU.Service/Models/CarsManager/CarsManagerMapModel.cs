using FU.Domain.Entities.Car.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Models.CarsManager
{
    public class CarsManagerMapModel
    {
        public string Name { get;  set; }
        public string? Description { get;  set; }
        public string? LogoPath { get;  set; }

        public ICollection<CarViewModel> Cars { get; set; }
    }
}
