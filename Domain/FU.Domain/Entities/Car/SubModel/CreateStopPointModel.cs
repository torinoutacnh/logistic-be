using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
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
    }
}
