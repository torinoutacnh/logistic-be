using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.LocalLocation
{
    public class WardEntity:LocalLocation
    {
        public Guid DistrictId { get; private set; }
        public virtual DistrictEntity? District { get; }

        private WardEntity() { }

        public WardEntity(string name, uint code, string codeName, string division, uint phoneCdoe, Guid districtId) : base(name, code, codeName, division, phoneCdoe)
        {
            DistrictId = districtId;
        }
    }
}
