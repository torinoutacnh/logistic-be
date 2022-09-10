using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FU.Domain.Entities.LocalLocation.SubModel;

namespace FU.Domain.Entities.LocalLocation
{
    public class WardEntity:BaseLocation
    {
        public string ShortCodeName { get; private set; }
        public Guid DistrictId { get; private set; }

        public virtual DistrictEntity? District { get; }

        private WardEntity() { }

        public WardEntity(string name, uint code, string codeName, string division, uint phoneCdoe, Guid districtId, string shortCodeName) : base(name, code, codeName, division)
        {
            DistrictId = districtId;
            ShortCodeName = shortCodeName;
        }
    }
}
