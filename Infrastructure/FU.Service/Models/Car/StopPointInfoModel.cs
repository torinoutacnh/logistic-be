using FU.Domain.Entities.StopPoint;

namespace FU.Service.Models.Car
{
    public class StopPointInfoModel
    {
        public Guid Id { get; set; }
        public Location Location { get; set; }
        public DetailLocation? DetailLocation { get; set; }
    }
}