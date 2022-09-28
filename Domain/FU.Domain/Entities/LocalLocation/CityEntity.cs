using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FU.Domain.Entities.LocalLocation.SubModel;

namespace FU.Domain.Entities.LocalLocation
{
    public class CityEntity : BaseLocation
    {
        public uint PhoneCode { get; protected set; }
        public virtual ICollection<DistrictEntity>? Districts { get; }

        private CityEntity() { }

        public CityEntity(string name, uint code, string codeName, string division, uint phoneCode) : base(name, code, codeName, division)
        {
            this.PhoneCode = phoneCode;
        }
    }
}
