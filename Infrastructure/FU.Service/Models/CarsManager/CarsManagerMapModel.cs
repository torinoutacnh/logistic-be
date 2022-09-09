using FU.Service.Models.Car;
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

        public ICollection<CarInfoModel> Cars { get; set; }
    }
}
