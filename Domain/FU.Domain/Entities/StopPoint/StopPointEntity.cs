using FU.Domain.Base;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.StopPoint
{
    public class StopPointEntity:Entity
    {
        public Location Location { get; private set; }
        public DetailLocation? DetailLocation { get; private set; }

        public Guid CarId { get; private set; }
        public virtual CarEntity? Car { get; private set; }

        public virtual ICollection<RouteEntity>? FromRoutes { get; init; }
        public virtual ICollection<RouteEntity>? ToRoutes { get; init; }

        private StopPointEntity() { }

        public StopPointEntity(Guid carid, Location location, DetailLocation? detailLocation = null)
        {
            CarId = carid;
            Location = location ?? throw new ArgumentNullException(nameof(location));
            DetailLocation = detailLocation;
        }

        public void UpdateLocation(Location location)
        {
            Location = location;
        }

        public void UpdateDetailLocation(DetailLocation detailLocation)
        {
            DetailLocation = detailLocation;
        }
    }
}
