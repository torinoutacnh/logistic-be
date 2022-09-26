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
            var query = _store.Cars.Where(x => x.IsDeleted == false)
                .Include(x => x.CarRouteMappings).ThenInclude(x => x.Route)
                .Include(x => x.Seats)
                .Select(x => new CarInfoModel(x,
                    x.Seats
                        .Where(y => y.IsDeleted == false)
                        .Select(y => new SeatModel(y)),
                    x.CarRouteMappings
                        .Where(y => y.IsDeleted == false)
                        .Select(x => new RouteModel(x.Id
                            , x.CarId
                            , new LocationInfo(
                                _store.Cities.First(y => y.Id == x.Route.From.CityId).Name
                                , _store.Districts.First(y => y.Id == x.Route.From.DistrictId).Name
                                , _store.Wards.First(y => y.Id == x.Route.From.WardId).Name
                                )
                            , new LocationInfo(
                                _store.Cities.First(y => y.Id == x.Route.To.CityId).Name
                                , _store.Districts.First(y => y.Id == x.Route.To.DistrictId).Name
                                , _store.Wards.First(y => y.Id == x.Route.To.WardId).Name
                                )
                            , x.Route.DistanceByKm
                            , x.Route.Day
                            , x.Route.Hour
                            , x.Route.Minute
                            )
                        )));

            return query.ToListAsync();
        }

        public Task<CarInfoModel?> GetCarInfo(Guid id)
        {
            var query = _store.Cars.Where(x => x.Id == id && x.IsDeleted == false)
                .Include(x => x.CarRouteMappings).ThenInclude(x => x.Route)
                .Include(x => x.Seats)
                .Select(x => new CarInfoModel(x,
                    x.Seats
                        .Where(y=>y.IsDeleted==false)
                        .Select(y => new SeatModel(y)),
                    x.CarRouteMappings
                        .Where(y => y.IsDeleted == false)
                        .Select(x => new RouteModel(x.Id
                            , x.CarId
                            , new LocationInfo(
                                _store.Cities.First(y => y.Id == x.Route.From.CityId).Name
                                , _store.Districts.First(y => y.Id == x.Route.From.DistrictId).Name
                                , _store.Wards.First(y => y.Id == x.Route.From.WardId).Name
                                )
                            , new LocationInfo(
                                _store.Cities.First(y => y.Id == x.Route.To.CityId).Name
                                , _store.Districts.First(y => y.Id == x.Route.To.DistrictId).Name
                                , _store.Wards.First(y => y.Id == x.Route.To.WardId).Name
                                )
                            , x.Route.DistanceByKm
                            , x.Route.Day
                            , x.Route.Hour
                            , x.Route.Minute
                            )
                        )));
            
            return query.FirstOrDefaultAsync();
        }
    }
}
