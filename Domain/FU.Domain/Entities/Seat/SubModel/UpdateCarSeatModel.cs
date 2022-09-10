using FU.Domain.Entities.CarsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Seat.SubModel
{
    public class UpdateCarSeatDetailModel
    {
        public Guid Id { get; set; }
        public string Row { get; private set; }
        public string Col { get; private set; }

        public UpdateCarSeatDetailModel(Guid id, string row, string col)
        {
            Id = id;
            Row = row;
            Col = col;
        }
    }

    public class UpdateCarSeatStatusModel
    {
        public Guid Id { get; set; }
        public SeatStatus Status { get; private set; }

        public UpdateCarSeatStatusModel(Guid id, SeatStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}
