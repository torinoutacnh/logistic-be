using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarsManager.SubModel
{
    public class UpdateCarsManagerModel
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string? Description { get;  set; }
        public string? LogoPath { get;  set; }
    }
}
