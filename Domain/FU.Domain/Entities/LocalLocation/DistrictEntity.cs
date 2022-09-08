using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation
{
    public class DistrictEntity:LocalLocation
    {
        public Guid CityId { get; private set; }
        public virtual CityEntity? City { get; }

        public virtual ICollection<WardEntity>? Wards { get; }

        private DistrictEntity() { }

        public DistrictEntity(string name, uint code, string codeName, string division, uint phoneCdoe, Guid cityId) : base(name, code, codeName, division, phoneCdoe)
        {
            CityId = cityId;
        }
    }
}
