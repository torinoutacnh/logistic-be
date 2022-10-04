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
                        select (new Location(city.Id, district.Id, ward.Id));

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

        public Task<List<RouteModel>> GetAllRoutes()
        {
            var query = _store.Routes.Where(x => x.IsDeleted == false)
                .Select(x => new RouteModel(
                            x.Id
                            , new LocationInfo(
                                _store.Cities.First(y => y.Id == x.From.CityId).Name
                                , _store.Districts.First(y => y.Id == x.From.DistrictId).Name
                                , _store.Wards.First(y => y.Id == x.From.WardId).Name
                                )
                            , new LocationInfo(
                                _store.Cities.First(y => y.Id == x.To.CityId).Name
                                , _store.Districts.First(y => y.Id == x.To.DistrictId).Name
                                , _store.Wards.First(y => y.Id == x.To.WardId).Name
                                )
                            , x.DistanceByKm
                            , x.Day
                            , x.Hour
                            , x.Minute
                            ));
            return query.ToListAsync();
        }
    }
}
