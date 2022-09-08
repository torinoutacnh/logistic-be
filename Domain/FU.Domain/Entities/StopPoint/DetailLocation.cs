using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.StopPoint
{
    public class DetailLocation : ValueObject
    {
        public string Longitude { get; private set; }
        public string Latitude { get; private set; }

        private DetailLocation() { }

        public DetailLocation(string longitude, string latitude)
        {
            Longitude = longitude ?? throw new ArgumentNullException(nameof(latitude));
            Latitude = latitude ?? throw new ArgumentNullException(nameof(longitude));
        }

        public void Update(string? longitude = null, string? latitude = null)
        {
            Longitude = longitude ?? throw new ArgumentNullException(nameof(latitude));
            Latitude = latitude ?? throw new ArgumentNullException(nameof(longitude));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Longitude, Latitude };
        }
    }
}
