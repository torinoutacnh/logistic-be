using FU.Domain.Entities.CarsManager;

namespace FU.Service.Models.Car
{
    public class SeatMapModel
    {
        public string Row { get; private set; }
        public string Col { get; private set; }
        public SeatStatus Status { get; private set; }
    }
}
