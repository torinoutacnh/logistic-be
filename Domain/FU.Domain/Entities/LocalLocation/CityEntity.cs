using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation
{
    public class CityEntity : LocalLocation
    {
        public virtual ICollection<DistrictEntity>? Districts { get; }

        private CityEntity() { }

        public CityEntity(string name, uint code, string codeName, string division, uint phoneCdoe) : base(name, code, codeName, division, phoneCdoe)
        {
        }
    }
}
