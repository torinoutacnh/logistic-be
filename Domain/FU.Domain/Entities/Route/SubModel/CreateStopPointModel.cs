using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route.SubModel
{
    public class CreateStopPointModel
    {
        public Guid CityId { get; private set; }
        public Guid DistrictId { get; private set; }
        public Guid WardId { get; private set; }

        public string? Street { get; private set; }
        public string? HouseNumber { get; private set; }

        public string? Longitude { get; private set; }
        public string? Latitude { get; private set; }

        public CreateStopPointModel(Guid cityId, Guid districtId, Guid wardId, string? street, string? houseNumber, string? longitude, string? latitude)
        {
            CityId = cityId;
            DistrictId = districtId;
            WardId = wardId;
            Street = street;
            HouseNumber = houseNumber;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
