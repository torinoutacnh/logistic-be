using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Ticket
{
    public class TicketEntity:Entity
    {
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public decimal Price { get; private set; }
        public ItemDetail? ItemDetail { get; private set; }
        public TicketServiceType TicketService { get; private set; }

        private TicketEntity() { }

        public TicketEntity(Guid carId, Guid routeId, decimal price, ItemDetail? itemDetail = null, TicketServiceType ticketService = TicketServiceType.Travel)
        {
            if (ticketService == TicketServiceType.Carry && itemDetail == null)
                throw new ArgumentException("Required item detail for shipping");
            CarId = carId;
            RouteId = routeId;
            Price = price;
            ItemDetail = itemDetail;
            TicketService = ticketService;
        }
    }
}
