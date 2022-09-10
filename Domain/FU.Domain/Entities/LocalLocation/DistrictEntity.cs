using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FU.Domain.Entities.LocalLocation.SubModel;

namespace FU.Domain.Entities.LocalLocation
{
    public class DistrictEntity:BaseLocation
    {
        public Guid CityId { get; private set; }
        public string ShortCodeName { get; private set; }

        public virtual CityEntity? City { get; }

        public virtual ICollection<WardEntity>? Wards { get; }

        private DistrictEntity() { }

        public DistrictEntity(string name, uint code, string codeName, string division, string shortCodeName, Guid cityId) : base(name, code, codeName, division)
        {
            CityId = cityId;
            ShortCodeName = shortCodeName;
        }
    }
}
