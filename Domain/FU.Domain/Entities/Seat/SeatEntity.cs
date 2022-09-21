using FU.Domain.Base;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.CarsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Seat
{
    public class SeatEntity : Entity
    {
        public string Row { get; private set; }
        public string Col { get; private set; }
        public int Floor { get; private set; }
        public SeatStatus Status { get; private set; }

        public Guid CarId { get; private set; }
        public virtual CarEntity Car { get; }

        private SeatEntity() { }

        public SeatEntity(string row, string col, int floor, Guid carId)
        {
            Row = row;
            Col = col;
            Floor = floor;
            CarId = carId;
            Status = SeatStatus.Available;
        }

        public void UpdateSeat(string row, string col, int floor)
        {
            Row = row;
            Col = col;
            Floor = floor;
        }

        public void UpdateStatus(SeatStatus status)
        {
            Status = status;
        }
    }
}
