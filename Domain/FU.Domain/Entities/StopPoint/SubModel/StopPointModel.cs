using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.StopPoint.SubModel
{
    public class StopPointModel
    {
        public Guid Id { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string Ward { get; private set; }

        public string? Street { get; private set; }
        public string? HouseNumber { get; private set; }

        public string? Longitude { get; private set; }
        public string? Latitude { get; private set; }

        public StopPointModel(Guid id, string city, string district, string ward, string? street, string? houseNumber, string? longitude, string? latitude)
        {
            Id = id;
            City = city;
            District = district;
            Ward = ward;
            Street = street;
            HouseNumber = houseNumber;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
