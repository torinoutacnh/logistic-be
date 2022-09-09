using FU.Domain.Entities.StopPoint;

namespace FU.Service.Models.Car
{
    public class StopPointMapModel
    {
        public Location Location { get; set; }
        public DetailLocation? DetailLocation { get; set; }
    }
}
