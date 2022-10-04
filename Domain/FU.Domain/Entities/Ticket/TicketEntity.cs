using FU.Domain.Base;
using FU.Domain.Entities.Mapping;
using FU.Domain.Entities.Seat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Ticket
{
    public class TicketEntity : Entity
    {
        public Guid CarId { get; private set; }
        public Guid RouteId { get; private set; }
        public Guid SeatId { get; private set; }
        public Guid CarRouteMappingId { get; private set; }
        public decimal Price { get; private set; }
        public ItemDetail? ItemDetail { get; private set; }
        public TicketServiceType TicketService { get; private set; }
        public virtual SeatEntity Seat { get; private set; }
        public virtual CarRouteMappingEntity CarRouteMapping { get; private set; }


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

        public TicketEntity(Guid carId, Guid routeId, Guid carRouteMappingId, Guid seatId, decimal price, ItemDetail? itemDetail = null, TicketServiceType ticketServiceType = TicketServiceType.Travel)
        {
            if (ticketServiceType == TicketServiceType.Carry && itemDetail == null)
                throw new ArgumentException("Required item detail for shipping");
            CarId = carId;
            RouteId = routeId;
            CarRouteMappingId = carRouteMappingId;
            SeatId = seatId;
            Price = price;
            ItemDetail = itemDetail;
            TicketService = ticketServiceType;
        }

        public void UpdateTicketEntity(UpdateTicketModel model)
        {
            CarId = model.CarId;
            RouteId = model.RouteId;
            CarRouteMappingId = model.CarRouteMappingId;
            SeatId = model.SeatId;
            Price = model.Price;
            ItemDetail = model.ItemDetail;
            TicketService = model.TicketServiceType;
        }
    }
}
