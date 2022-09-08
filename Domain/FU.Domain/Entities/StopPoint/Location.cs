using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.StopPoint
{
    public class Location : ValueObject
    {
        public Guid CityId { get; private set; }
        public Guid DistrictId { get; private set; }
        public Guid WardId { get; private set; }

        public string? Street { get; private set; }
        public string? HouseNumber { get; private set; }

        private Location() { }

        public Location(Guid cityId, Guid districtId, Guid wardId, string? street = null,string? houseNumber = null)
        {
            CityId = cityId;
            DistrictId = districtId;
            WardId = wardId;
            Street = street;
            HouseNumber = houseNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { CityId, DistrictId, WardId };
        }
    }
}
