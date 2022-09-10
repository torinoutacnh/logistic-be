using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.LocalLocation.SubModel;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.StopPoint;
using FU.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Route
{
    public class ManageCarRouteDomainService : Service
    {
        private readonly ICarRepository _carRepository;
        private readonly IStopPointRepository _stopPointRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IDistrictRepository _districtRepository;

        public ManageCarRouteDomainService(IUnitOfWork unitOfWork,
            ICarRepository carRepository,
            IStopPointRepository stopPointRepository,
            IRouteRepository routeRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            IWardRepository wardRepository) : base(unitOfWork)
        {
            _carRepository = carRepository;
            _stopPointRepository = stopPointRepository;
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

        #region Car stop points
        /// <summary>
        /// Get Car Stops
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isIncludeDeleted"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<StopPointEntity>> GetCarStops(Expression<Func<StopPointEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<StopPointEntity, object>>[] includeProperties)
        {
            return await _stopPointRepository.GetAllAsync(expression, isIncludeDeleted, includeProperties);
        }

        /// <summary>
        /// Get Car Stops To
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="expression"></param>
        /// <param name="isIncludeDeleted"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<T>> GetCarStopsTo<T>(Func<StopPointEntity, T> func, Expression<Func<StopPointEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<StopPointEntity, object>>[] includeProperties)
        {
            var stopPoints = await _stopPointRepository.GetAllToAsync(func, expression, isIncludeDeleted, includeProperties);

            return stopPoints;
        }

        /// <summary>
        /// Create Stop Points
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<List<Guid>> CreateStopPoints(Guid carid, ICollection<CreateStopPointModel> models)
        {
            var check = await _carRepository.GetAsync(carid) ?? throw new DomainException(ShareConstant.NotFound, 404);
            var points = models.Select(
                x =>
                    new StopPointEntity(carid,
                        new Location(x.CityId, x.DistrictId, x.WardId, x.Street, x.HouseNumber),
                    x.Latitude != null && x.Longitude != null ?
                        new DetailLocation(x.Longitude, x.Latitude) :
                        null)
            ).DistinctBy(x => x.Location);

            await _stopPointRepository.CreateRangeAsync(points.ToArray());
            await _unitOfWork.SaveChangeAsync();
            return points.Select(x => x.Id).ToList();
        }

        /// <summary>
        /// Create Stop Point
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> CreateStopPoint(Guid carid, CreateStopPointModel model)
        {
            var check = await _carRepository.GetAsync(carid, false, x => x.StopPoints) ?? throw new DomainException(ShareConstant.NotFound, 404);

            var location = new Location(model.CityId, model.DistrictId, model.WardId, model.Street, model.HouseNumber);
            if(!_stopPointRepository.ValidateLocation(location)) 
                throw new DomainException(StoppointConstant.InvalidLocation, 400);

            var isDetail = string.IsNullOrEmpty(model.Longitude) || string.IsNullOrEmpty(model.Latitude);
            var detaiLocation = isDetail ? null : new DetailLocation(model.Longitude, model.Latitude);
            var point = new StopPointEntity(carid, location, detaiLocation);

            if (check.StopPoints?.Contains(point) ?? false) throw new DomainException(ShareConstant.Existed, 400);

            await _stopPointRepository.CreateAsync(point);
            await _unitOfWork.SaveChangeAsync();
            return point.Id;
        }

        /// <summary>
        /// Update StopPoint Location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateStopPointLocation(Guid id, Location model)
        {
            if (!_stopPointRepository.ValidateLocation(model)) 
                throw new DomainException(StoppointConstant.InvalidLocation, 400);
            var check = await _stopPointRepository.GetAsync(x => x.Id == id) 
                ?? throw new DomainException(ShareConstant.NotFound, 400);

            var isNotValid = (await _stopPointRepository
                .GetAllAsync(x => x.CarId == check.CarId && x.Id != id && x.Location == model))
                .Any();
            if (isNotValid) new DomainException(StoppointConstant.StoppointExisted, 400);

            check.UpdateLocation(model);
            await _stopPointRepository.UpdateAsync(check);
            await _unitOfWork.SaveChangeAsync();
            return check.Id;
        }

        /// <summary>
        /// Update StopPoint Detail Location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateStopPointDetailLocation(Guid id, DetailLocation model)
        {
            var check = await _stopPointRepository.GetAsync(x => x.Id == id) ?? throw new DomainException(ShareConstant.NotFound, 400);

            var isNotValid = (await _stopPointRepository
                .GetAllAsync(x => x.CarId == check.CarId && x.Id != id && x.DetailLocation == model))
                .Any();
            if (isNotValid) new DomainException(StoppointConstant.StoppointExisted, 400);

            check.UpdateDetailLocation(model);
            await _stopPointRepository.UpdateAsync(check);
            await _unitOfWork.SaveChangeAsync();
            return check.Id;
        }

        /// <summary>
        /// Delete Stop Point
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteStopPoint(Guid id)
        {
            await _stopPointRepository.DeleteAsync(id, true);
            await _unitOfWork.SaveChangeAsync();
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

            var routes = models.Select(x => new RouteEntity(carid, x.FromId, x.ToId, x.DistanceByKm, x.Day, x.Hour, x.Minute)).DistinctBy(x => new { from = x.FromId, to = x.ToId }).ToArray();
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
            var check = await _carRepository.GetAsync(carid, false, x => x.Routes) ?? throw new DomainException(ShareConstant.NotFound, 404);
            if (check.Routes?.Where(x => x.FromId == model.FromId && x.ToId == model.ToId).Any() ?? false) throw new DomainException(CarConstant.RouteExisted, 400);

            var route = new RouteEntity(carid, model.FromId, model.ToId, model.DistanceByKm, model.Day, model.Hour, model.Minute);
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
            await _routeRepository.DeleteAsync(id);
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
            var car = await _carRepository.GetAsync(check.CarId, false, x => x.Routes);
            if (car.Routes?.Where(x => x.FromId == model.FromId && x.ToId == model.ToId && x.Id != id).Any() ?? false) throw new DomainException(CarConstant.RouteExisted, 400);

            check.Update(model.FromId, model.ToId, model.DistanceByKm, model.Day, model.Hour, model.Minute);
            await _routeRepository.UpdateAsync(check);
            await _unitOfWork.SaveChangeAsync();
            return check.Id;
        }
        #endregion
    }
}
