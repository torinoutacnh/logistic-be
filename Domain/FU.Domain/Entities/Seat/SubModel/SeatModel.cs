using FU.Domain.Entities.CarsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Seat.SubModel
{
    public class SeatModel
    {
        public Guid Id { get; private set; }
        public string Row { get; private set; }
        public string Col { get; private set; }
        public int Floor { get; private set; }
        public SeatStatus Status { get; private set; }

        public SeatModel(string row, string col, int floor, SeatStatus status)
        {
            Row = row;
            Col = col;
            Floor = floor;
            Status = status;
        }

        public SeatModel(SeatEntity seat)
        {
            Id = seat.Id;
            Row = seat.Row;
            Col = seat.Col;
            Floor = seat.Floor;
            Status = seat.Status;
        }
    }
}
