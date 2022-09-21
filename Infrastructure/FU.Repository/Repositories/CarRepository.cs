using FU.Domain.Entities.Car;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using FU.Domain.Entities.StopPoint.SubModel;
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
    public class CarRepository : Repository<CarEntity>, ICarRepository
    {
        public CarRepository(Store store) : base(store)
        {
        }

        public Task<List<CarInfoModel>> GetCarInfos()
        {
            var query = from car in _store.Cars
                        join manager in _store.CarsManagers
                            on car.CarsManagerId equals manager.Id
                        select new CarInfoModel(car,
                        car.Seats.Select(x => new SeatModel(x)),
                        car.Routes.Select(x => new RouteModel(x)),
                        car.StopPoints.Select(x => new StopPointModel(
                            x.Id,
                            (from city in _store.Cities
                             where city.Id == x.Location.CityId
                             select city.Name).FirstOrDefault(),
                            (from district in _store.Districts
                             where district.Id == x.Location.DistrictId
                             select district.Name).FirstOrDefault(),
                            (from ward in _store.Wards
                             where ward.Id == x.Location.WardId
                             select ward.Name).FirstOrDefault(),
                            x.Location.Street,
                            x.Location.HouseNumber,
                            x.DetailLocation.Longitude,
                            x.DetailLocation.Latitude))
                        );
            return query.ToListAsync();
        }

        public Task<CarInfoModel> GetCarInfo(Guid id)
        {
            var query = from car in _store.Cars.Include(x=>x.CarsManager)
                        where car.Id == id
                        select new CarInfoModel(car,
                        car.Seats.Select(x=>new SeatModel(x)), 
                        car.Routes.Select(x => new RouteModel(x)), 
                        car.StopPoints.Select(x => new StopPointModel(
                            x.Id,
                            (from city in _store.Cities
                             where city.Id == x.Location.CityId
                             select city.Name).FirstOrDefault(),
                            (from district in _store.Districts
                             where district.Id == x.Location.DistrictId
                             select district.Name).FirstOrDefault(),
                            (from ward in _store.Wards
                             where ward.Id == x.Location.WardId
                             select ward.Name).FirstOrDefault(),
                            x.Location.Street,
                            x.Location.HouseNumber,
                            x.DetailLocation.Longitude,
                            x.DetailLocation.Latitude))
                        );
            return query.FirstOrDefaultAsync();
        }
    }
}
