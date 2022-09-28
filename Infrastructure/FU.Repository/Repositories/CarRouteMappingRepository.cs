﻿using FU.Domain.Entities.CarRouteMapping;
using FU.Domain.Entities.CarRouteMapping.SubModel;
using FU.Domain.Entities.Mapping;
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
    public class CarRouteMappingRepository : Repository<CarRouteMappingEntity>, ICarRouteMappingRepository
    {
        public CarRouteMappingRepository(Store store) : base(store)
        {         
        }

        public Task<List<CarRouteMappingInfoModel>> GetCarRouteByLocationStarttime(Guid FromCityId, Guid ToCityId, DateTimeOffset Starttime)
        {
            var query = from route in _store.Routes
                        where route.From.CityId == FromCityId && route.To.CityId == ToCityId
                        join mapping in _store.CarRouteMappings
                        on route.Id equals mapping.RouteId
                        where mapping.Starttime == Starttime
                        select new CarRouteMappingInfoModel(mapping.CarId, route.Id, mapping.Starttime);
            return query.ToListAsync();
        }

        public Task<CarRouteMappingInfoModel?> GetCarRouteMappingInfo(Guid id)
        {
            var query =  from mapping in _store.CarRouteMappings
                         where mapping.IsDeleted == false && mapping.CarId == id
                         join car in _store.Cars
                        on mapping.CarId equals car.Id
                         join route in _store.Routes
                         on mapping.CarId equals route.Id
                         select new CarRouteMappingInfoModel(car.Id, route.Id, mapping.Starttime);
            return query.FirstOrDefaultAsync();
        }

        public Task<List<CarRouteMappingInfoModel>> GetCarRouteMappingInfos()
        {
            var query = from mapping in _store.CarRouteMappings
                        where mapping.IsDeleted == false
                        join car in _store.Cars
                        on mapping.CarId equals car.Id
                        join route in _store.Routes
                        on mapping.CarId equals route.Id
                        select new CarRouteMappingInfoModel(car.Id, route.Id, mapping.Starttime);
            return query.ToListAsync();
        }
    }
}
