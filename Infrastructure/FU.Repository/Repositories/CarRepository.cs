using FU.Domain.Entities.Car;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using FU.Infras.CustomAttribute;
using FU.Repository.Base;
using FU.Repository.DbStore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Repositories
{
    [RegisterScope]
    public class CarRepository : Repository<CarEntity>, ICarRepository
    {
        private readonly IRouteRepository _routeRepository;
        public CarRepository(Store store) : base(store)
        {
            _routeRepository = new RouteRepository(store);
        }

        public Task<List<CarInfoModel>> GetCarInfos()
        {
            var query = from car in _store.Cars
                        where car.IsDeleted == false
                        join mapping in _store.CarRouteMappings
                        on car.Id equals mapping.CarId
                        select new CarInfoModel(car,
                        car.Seats.Select(x => new SeatModel(x)),
                        from route in _store.Routes
                        where route.Id == mapping.RouteId
                        select new RouteModel(route.Id,
                        route.CarId,
                        (from city in _store.Cities
                         where city.Id == route.From.CityId
                         join district in _store.Districts
                            on route.From.DistrictId equals district.Id
                         join ward in _store.Wards
                            on route.From.WardId equals ward.Id
                         select new LocationInfo(city.Name, district.Name, ward.Name)).First(),
                         (from city in _store.Cities
                          where city.Id == route.To.CityId
                          join district in _store.Districts
                             on route.To.DistrictId equals district.Id
                          join ward in _store.Wards
                             on route.To.WardId equals ward.Id
                          select new LocationInfo(city.Name, district.Name, ward.Name)).First(),
                         route.DistanceByKm,
                         route.Day,
                         route.Hour,
                         route.Minute,
                         route.DailyStartTime));

            return query.ToListAsync();
        }

        public Task<CarInfoModel?> GetCarInfo(Guid id)
        {
            var query = (from car in _store.Cars
                        where car.IsDeleted == false && car.Id == id
                        join mapping in _store.CarRouteMappings
                        on car.Id equals mapping.CarId
                        select new CarInfoModel(car,
                        car.Seats.Select(x => new SeatModel(x)),
                        from route in _store.Routes
                        where route.Id == mapping.RouteId
                        select new RouteModel(route.Id,
                        route.CarId,
                        (from city in _store.Cities
                            where city.Id == route.From.CityId
                            join district in _store.Districts
                            on route.From.DistrictId equals district.Id
                            join ward in _store.Wards
                            on route.From.WardId equals ward.Id
                            select new LocationInfo(city.Name, district.Name, ward.Name)).First(),
                            (from city in _store.Cities
                            where city.Id == route.To.CityId
                            join district in _store.Districts
                                on route.To.DistrictId equals district.Id
                            join ward in _store.Wards
                                on route.To.WardId equals ward.Id
                            select new LocationInfo(city.Name, district.Name, ward.Name)).First(),
                            route.DistanceByKm,
                            route.Day,
                            route.Hour,
                            route.Minute,
                            route.DailyStartTime))).FirstOrDefaultAsync();
            return query;
        }
    }
}
