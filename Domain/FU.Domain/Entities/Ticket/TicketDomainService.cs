using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.CarRouteMapping;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.Seat;
using FU.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Ticket
{
    public class TicketDomainService : Service
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarsManagerRepository _carsManagerRepository;
        private readonly ICarRouteMappingRepository _carRouteMappingRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly ITicketRepository _ticketRepository;

        public TicketDomainService(IUnitOfWork unitOfWork,
            ICarRepository carRepository,
            ICarsManagerRepository carsManagerRepository,
            ISeatRepository seatRepository,
            ITicketRepository ticketRepository) : base(unitOfWork)
        {
            _carRepository = carRepository;
            _carsManagerRepository = carsManagerRepository;
            _seatRepository = seatRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketViewModel>> GetTicketList()
        {
            var tickets = await _ticketRepository.GetAllTickets();
            return tickets;
        }
        public async Task<TicketViewModel> GetTicket(Guid id)
        {
            var ticket = await _ticketRepository.GetTicketById(id);
            return ticket;
        }

        public async Task<Guid> CreateTicket(CreateTicketModel model)
        {
            var ticket = new TicketEntity(model.CarId, model.RouteId, model.CarRouteMappingId, model.SeatId,model.Price, model.ItemDetail, model.TicketServiceType);

            await _ticketRepository.CreateAsync(ticket);
            await _unitOfWork.SaveChangeAsync();
            return ticket.Id;
        }

        public async Task<Guid> UpdateTicket(UpdateTicketModel model)
        {
            var ticket = await _ticketRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound, 404);
            //var routemapping = await _carRouteMappingRepository.GetAsync(model.CarRouteMappingId) ?? throw new DomainException(ShareConstant.NotFound, 404);
            //if (routemapping.CarId != model.CarId || routemapping.RouteId != model.RouteId) {
            //    throw new DomainException("Car and route have not been mapped."); }

            var seat = await _seatRepository.GetAsync(model.SeatId) ?? throw new DomainException(ShareConstant.NotFound,404);
            
            ticket.UpdateTicketEntity(model);
            await _ticketRepository.UpdateAsync(ticket);
            await _unitOfWork.SaveChangeAsync();
            return ticket.Id;
        }

        public async Task DeleteTicket(Guid id)
        {
            await _ticketRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
