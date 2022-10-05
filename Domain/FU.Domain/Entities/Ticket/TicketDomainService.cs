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
            ICarRouteMappingRepository carRouteMappingRepository,
            ISeatRepository seatRepository,
            ITicketRepository ticketRepository) : base(unitOfWork)
        {
            _carRepository = carRepository;
            _carsManagerRepository = carsManagerRepository;
            _carRouteMappingRepository = carRouteMappingRepository;
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
            // validate
            var seat = await _seatRepository.GetAsync(x => x.Id == model.SeatId && x.CarId == model.CarId) ?? throw new DomainException(ShareConstant.NotFound, 404);
            var ticketCheck = await _ticketRepository.GetAsync(x => x.SeatId == model.SeatId && x.CarRouteMappingId == model.CarRouteMappingId);
            if (ticketCheck != null) throw new DomainException("Seat is not available.");


            var ticket = new TicketEntity(model.CarId, model.RouteId, model.CarRouteMappingId, model.SeatId,model.Price, model.ItemDetail, model.TicketServiceType);

            await _ticketRepository.CreateAsync(ticket);
            await _unitOfWork.SaveChangeAsync();
            return ticket.Id;
        }

        public async Task<Guid> UpdateTicketSeat(UpdateTicketSeatModel model)
        {
            var ticket = await _ticketRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound, 404);

            var seat = await _seatRepository.GetAsync(x=> x.Id == model.SeatId && x.CarId == ticket.CarId) ?? throw new DomainException("Seat is not found in the car.",404);

            if (ticket.SeatId != model.SeatId)
            {
                var checkTicketExist = await _ticketRepository.GetAsync(x => x.SeatId == model.SeatId && x.CarRouteMappingId == ticket.CarRouteMappingId);
                if (checkTicketExist != null) throw new DomainException("Seat or mapping are not available.");
            }
            
            ticket.UpdateTicketSeat(model);
            await _ticketRepository.UpdateAsync(ticket);
            await _unitOfWork.SaveChangeAsync();
            return ticket.Id;
        }
        public async Task<Guid> UpdateTicketMapping(UpdateTicketMappingModel model)
        {
            var ticket = await _ticketRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound, 404);
            var mapping = await _carRouteMappingRepository.GetAsync(model.CarRouteMappingId) ?? throw new DomainException("Mapping not found", 404);
            var seat = await _seatRepository.GetAsync(x => x.Id == ticket.SeatId && x.CarId == mapping.CarId) ?? throw new DomainException("Seat is not found in the car.", 404);

            var checkSeat = await _ticketRepository.GetAsync(x => x.SeatId == ticket.SeatId && x.CarRouteMappingId == model.CarRouteMappingId);
            if (checkSeat != null) throw new DomainException("Seat are not available.");

            ticket.UpdateTicketMapping(mapping);
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
