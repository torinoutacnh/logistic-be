using FU.Domain.Entities.Car;
using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.StopPoint;
using FU.Domain.Entities.StopPoint.SubModel;
using FU.Infras.CustomAttribute;
using FU.Repository.Base;
using FU.Repository.DbStore;
using FU.Repository.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Repositories
{
    [RegisterScope]
    public class StopPointRepository : Repository<StopPointEntity>, IStopPointRepository
    {
        public StopPointRepository(Store store) : base(store)
        {
        }

        public Task<StopPointModel?> GetStopPointDetail(Guid pointId)
        {
            var query = from stop in _store.Set<StopPointEntity>()
                        join city in _store.Set<CityEntity>()
                            on stop.Location.CityId equals city.Id
                        join district in _store.Set<DistrictEntity>()
                            on stop.Location.DistrictId equals district.Id
                        join ward in _store.Set<WardEntity>()
                            on stop.Location.WardId equals ward.Id
                        where stop.Id == pointId
                        select new StopPointModel(
                            city.Name, 
                            district.Name, 
                            ward.Name, 
                            stop.Location.Street, 
                            stop.Location.HouseNumber, 
                            stop.DetailLocation.Longitude, 
                            stop.DetailLocation.Latitude);

            return query.FirstOrDefaultAsync();
        }

        public Task<List<StopPointModel>> GetStopPointDetails(Guid carId)
        {
            var query = from car in _store.Set<CarEntity>()
                        join stop in _store.Set<StopPointEntity>()
                            on car.Id equals stop.CarId
                        join city in _store.Set<CityEntity>()
                            on stop.Location.CityId equals city.Id
                        join district in _store.Set<DistrictEntity>()
                            on stop.Location.DistrictId equals district.Id
                        join ward in _store.Set<WardEntity>()
                            on stop.Location.WardId equals ward.Id
                        where car.Id == carId
                        select new StopPointModel(
                            city.Name,
                            district.Name,
                            ward.Name,
                            stop.Location.Street,
                            stop.Location.HouseNumber,
                            stop.DetailLocation.Longitude,
                            stop.DetailLocation.Latitude);

            return query.ToListAsync();
        }

        public bool ValidateLocation(Location model)
        {
            var query = from city in _store.Cities
                        where city.Id == model.CityId
                        join district in _store.Districts
                            on city.Id equals district.CityId
                        where district.Id == model.DistrictId
                        join ward in _store.Wards
                            on district.Id equals ward.DistrictId
                        where ward.Id == model.WardId
                        select (new Location(city.Id, district.Id, ward.Id,"",""));

            return query.Any();
        }
    }
}
