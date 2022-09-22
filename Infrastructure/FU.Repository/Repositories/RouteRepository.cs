using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.Route.SubModel;
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
    public class RouteRepository : Repository<RouteEntity>, IRouteRepository
    {
        public RouteRepository(Store store) : base(store)
        {
        }

        public Task<RouteModel?> GetRouteDetailAsync(Guid id)
        {
            var query = from route in _store.Routes
                        where route.Id == id
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
                         route.Minute);

            return query.FirstOrDefaultAsync();
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
                        select (new Location(city.Id, district.Id, ward.Id, "", ""));

            return query.Any();
        }

        public bool ValidateLocations(params Location[] models)
        {
            if(!models.Any()) return false;
            foreach(var model in models)
            {
                if (!ValidateLocation(model))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
