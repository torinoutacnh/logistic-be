using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.LocalLocation.SubModel;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route
{
    public class ManageCarRouteDomainService : Service
    {
        private readonly ICarRepository _carRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IDistrictRepository _districtRepository;

        public ManageCarRouteDomainService(IUnitOfWork unitOfWork,
            ICarRepository carRepository,
            IRouteRepository routeRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            IWardRepository wardRepository) : base(unitOfWork)
        {
            _carRepository = carRepository;
            _routeRepository = routeRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
        }

        #region location
        /// <summary>
        /// Get Cities
        /// </summary>
        /// <returns></returns>
        public async Task<List<CityViewModel>> GetCities()
        {
            var cities = (await _cityRepository.GetAllAsync(x => true)).Select(x=>new CityViewModel(x));
            return cities.ToList();
        }

        /// <summary>
        /// Get Districts From City
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<List<DistrictViewModel>> GetDistrictsFromCity(Guid cityId)
        {
            var districts = (await _districtRepository.GetAllAsync(x => x.CityId== cityId)).Select(x => new DistrictViewModel(x));
            return districts.ToList();
        }

        /// <summary>
        /// Get Wards From District
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public async Task<List<WardViewModel>> GetWardsFromDistrict(Guid districtId)
        {
            var wards = (await _wardRepository
                .GetAllAsync(x => x.DistrictId == districtId))
                .Select(x => new WardViewModel(x));
            return wards.ToList();
        }
        #endregion

        #region Car routes
        /// <summary>
        /// Create Car Routes
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<List<Guid>> CreateCarRoutes(Guid carid, params CreateCarRouteModel[] models)
        {
            var check = await _carRepository.GetAsync(carid) ?? throw new DomainException(ShareConstant.NotFound, 404);
            if (!_routeRepository.ValidateLocations(models
                .Select(x=>x.From)
                .Concat(models.Select(x => x.To))
                .Distinct()
                .ToArray()))
                throw new DomainException(CarConstant.InvalidLocation, 400);

            var routes = models.Select(x => new RouteEntity(carid, x.From, x.To, x.DistanceByKm, x.Day, x.Hour, x.Minute, x.DailyStartTime)).DistinctBy(x => new { from = x.From, to = x.To }).ToArray();
            await _routeRepository.CreateRangeAsync(routes);
            await _unitOfWork.SaveChangeAsync();
            return routes.Select(x => x.Id).ToList();
        }

        /// <summary>
        /// Create Car Route
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> CreateCarRoute(Guid carid, CreateCarRouteModel model)
        {
            var check = await _carRepository.GetAsync(carid) ?? throw new DomainException(ShareConstant.NotFound, 404);
            if(!_routeRepository.ValidateLocations(model.From, model.To)) 
                throw new DomainException(CarConstant.InvalidLocation, 400);

            var route = new RouteEntity(carid, model.From, model.To, model.DistanceByKm, model.Day, model.Hour, model.Minute, model.DailyStartTime);
            await _routeRepository.CreateAsync(route);
            await _unitOfWork.SaveChangeAsync();
            return route.Id;
        }

        /// <summary>
        /// Delete Car Route
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCarRoute(Guid id)
        {
            await _routeRepository.DeleteAsync(id,true);
            await _unitOfWork.SaveChangeAsync();
        }

        /// <summary>
        /// Update Car Route
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateCarRoute(Guid id, UpdateCarRouteModel model)
        {
            var check = await _routeRepository.GetAsync(id) ?? throw new DomainException(ShareConstant.NotFound, 404);
            if (!_routeRepository.ValidateLocations(model.From, model.To))
                throw new DomainException(CarConstant.InvalidLocation, 400);

            check.Update(model.From, model.To, model.DistanceByKm, model.Day, model.Hour, model.Minute,model.DailyStartTime);
            await _routeRepository.UpdateAsync(check);
            await _unitOfWork.SaveChangeAsync();
            return check.Id;
        }
        #endregion
    }
}
