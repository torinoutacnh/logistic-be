using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Ticket;
using FU.Infras.CustomAttribute;
using FU.Repository.Base;
using FU.Repository.DbStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Repositories
{
    [RegisterScope]
    public class TicketRepository : Repository<TicketEntity>, ITicketRepository
    {
        public TicketRepository(Store store) : base(store)
        {
        }

        public Task<List<TicketViewModel>> GetAllTickets()
        {
            var query = from ticket in _store.Tickets
                        where ticket.IsDeleted == false
                        join car in _store.Cars
                        on ticket.CarRouteMapping.CarId equals car.Id
                        where car.IsDeleted == false
                        join route in _store.Routes
                        on ticket.CarRouteMapping.RouteId equals route.Id
                        where route.IsDeleted == false
                        select new TicketViewModel(ticket, car, ticket.Seat,
                            new RouteModel(
                                    route.Id
                                    ,ticket.CarRouteMappingId
                                    , new LocationInfo(
                                        _store.Cities.First(y => y.Id == route.From.CityId).Name
                                        , _store.Districts.First(y => y.Id == route.From.DistrictId).Name
                                        , _store.Wards.First(y => y.Id == route.From.WardId).Name
                                        )
                                    , new LocationInfo(
                                        _store.Cities.First(y => y.Id == route.To.CityId).Name
                                        , _store.Districts.First(y => y.Id == route.To.DistrictId).Name
                                        , _store.Wards.First(y => y.Id == route.To.WardId).Name
                                        )
                                    , route.DistanceByKm
                                    , route.Day
                                    , route.Hour
                                    , route.Minute
                                    )
                        );
            return query.ToListAsync();
        }

        public Task<TicketViewModel> GetTicketById(Guid id)
        {
            var query = from ticket in _store.Tickets
                        where ticket.IsDeleted == false && ticket.Id == id
                        join car in _store.Cars
                        on ticket.CarRouteMapping.CarId equals car.Id
                        where car.IsDeleted == false
                        join route in _store.Routes
                        on ticket.CarRouteMapping.RouteId equals route.Id
                        where route.IsDeleted == false
                        select new TicketViewModel(ticket, car, ticket.Seat,
                            new RouteModel(
                                    route.Id
                                    , ticket.CarRouteMappingId
                                    , new LocationInfo(
                                        _store.Cities.First(y => y.Id == route.From.CityId).Name
                                        , _store.Districts.First(y => y.Id == route.From.DistrictId).Name
                                        , _store.Wards.First(y => y.Id == route.From.WardId).Name
                                        )
                                    , new LocationInfo(
                                        _store.Cities.First(y => y.Id == route.To.CityId).Name
                                        , _store.Districts.First(y => y.Id == route.To.DistrictId).Name
                                        , _store.Wards.First(y => y.Id == route.To.WardId).Name
                                        )
                                    , route.DistanceByKm
                                    , route.Day
                                    , route.Hour
                                    , route.Minute
                                    )
                        );
            return query.FirstOrDefaultAsync();
        }
    }
}
