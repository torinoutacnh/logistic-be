using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Ticket
{
    public class UpdateTicketSeatModel
    {
        public Guid Id { get; set; }
        public Guid SeatId { get; private set; }
        public decimal Price { get; private set; }
        public ItemDetail? ItemDetail { get; private set; }
        public TicketServiceType TicketServiceType { get; private set; }

        private UpdateTicketSeatModel() { }
        public UpdateTicketSeatModel(Guid id, Guid seatId, decimal price, ItemDetail? itemDetail = null, TicketServiceType ticketServiceType = TicketServiceType.Travel)
        {
            //if (ticketServiceType == TicketServiceType.Carry && itemDetail == null)
            //    throw new ArgumentException("Required item detail for shipping");
            if (ticketServiceType == TicketServiceType.Carry)
                itemDetail = null;
            Id = id;
            SeatId = seatId;
            Price = price;
            ItemDetail = itemDetail;
            TicketServiceType = ticketServiceType;
        }
    }

    public class UpdateTicketMappingModel
    {
        public Guid Id { get; set; }
        public Guid CarRouteMappingId { get; set; }

        private UpdateTicketMappingModel() {}

        public UpdateTicketMappingModel(Guid id, Guid carRouteMappingId)
        {
            Id = id;
            CarRouteMappingId = carRouteMappingId;
        }
    }
}
