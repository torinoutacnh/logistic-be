using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Ticket
{
    public class TicketViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public Guid SeatId { get; private set; }
        public Guid CarRouteMappingId { get; private set; }
        public decimal Price { get; private set; }
        public ItemDetail? ItemDetail { get; private set; }
        public TicketServiceType TicketServiceType { get; private set; }

        private TicketViewModel() { }
        public TicketViewModel(Guid id,Guid carId, Guid routeId, Guid carRouteMappingId, Guid seatId, decimal price, ItemDetail? itemDetail = null, TicketServiceType ticketServiceType = TicketServiceType.Travel)
        {
            //if (ticketServiceType == TicketServiceType.Carry && itemDetail == null)
            //    throw new ArgumentException("Required item detail for shipping");
            Id = id;
            CarId = carId;
            RouteId = routeId;
            CarRouteMappingId = carRouteMappingId;
            SeatId = seatId;
            Price = price;
            ItemDetail = itemDetail;
            TicketServiceType = ticketServiceType;
        }
        public TicketViewModel(TicketEntity ticket)
        {
            Id = ticket.Id;
            CarId = ticket.CarId;
            RouteId = ticket.RouteId;
            CarRouteMappingId = ticket.CarRouteMappingId;
            SeatId = ticket.SeatId;
            Price = ticket.Price;
            ItemDetail = ticket.ItemDetail;
            TicketServiceType = TicketServiceType;
        }
    }
}
