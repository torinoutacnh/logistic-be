using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route.SubModel
{
    public class LocationInfo
    {
        public string City { get; init; }
        public string District { get; init; }
        public string Ward { get; init; }

        public LocationInfo(string city, string district, string ward)
        {
            City = city;
            District = district;
            Ward = ward;
        }
    }
}
