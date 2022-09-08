using FU.Domain.Entities.CarsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car.SubModel
{
    public class CreateCarSeatModel
    {
        public string Row { get; private set; }
        public string Col { get; private set; }
        public SeatStatus Status { get; private set; }

        public CreateCarSeatModel(string row, string col, SeatStatus status)
        {
            Row = row;
            Col = col;
            Status = status;
        }
    }
}
