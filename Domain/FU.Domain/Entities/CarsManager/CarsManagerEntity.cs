using FU.Domain.Base;
using FU.Domain.Entities.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarsManager
{
    public class CarsManagerEntity:Entity
    {
        public string Name { get;private set; }
        public string? Description { get;private set; }
        public string? LogoPath { get;private set; }

        public virtual ICollection<CarEntity>? Cars { get; }

        private CarsManagerEntity() { }

        public CarsManagerEntity(string name, string? description = null, string? logoPath = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            LogoPath = logoPath;
        }

        public void Update(string name, string? description = null, string? logoPath = null)
        {
            Name = name;
            Description = description;
            LogoPath = logoPath;
        }
    }
}
