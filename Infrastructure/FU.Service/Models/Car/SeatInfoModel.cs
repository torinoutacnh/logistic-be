using FU.Domain.Entities.CarsManager;

namespace FU.Service.Models.Car
{
    public class SeatInfoModel
    {
        public Guid Id { get; set; }
        public string Row { get; private set; }
        public string Col { get; private set; }
        public SeatStatus Status { get; private set; }
    }
}