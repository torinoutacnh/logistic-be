using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route
{
    public class Location : ValueObject
    {
        public Guid CityId { get; private set; }
        public Guid DistrictId { get; private set; }
        public Guid WardId { get; private set; }


        private Location() { }

        public Location(Guid cityId, Guid districtId, Guid wardId)
        {
            CityId = cityId;
            DistrictId = districtId;
            WardId = wardId;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { CityId, DistrictId, WardId };
        }
    }
}
