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
        public string Row { get; private set; }
        public string Col { get; private set; }
        public SeatStatus Status { get; private set; }

        public SeatModel(string row, string col, SeatStatus status)
        {
            Row = row;
            Col = col;
            Status = status;
        }

        public SeatModel(SeatEntity seat)
        {
            Row = seat.Row;
            Col = seat.Col;
            Status = seat.Status;
        }
    }
}
