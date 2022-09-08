using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.StopPoint;
using FU.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Car
{
    public class CarDomainService : Service
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarsManagerRepository _carsManagerRepository;
        private readonly IStopPointRepository _stopPointRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IDistrictRepository _districtRepository;

        public CarDomainService(IUnitOfWork unitOfWork, 
            ICarRepository carRepository,
            ICarsManagerRepository carsManagerRepository, 
            IStopPointRepository stopPointRepository, 
            ISeatRepository seatRepository,
            IRouteRepository routeRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            IWardRepository wardRepository) : base(unitOfWork)
        {
            _carRepository = carRepository;
            _carsManagerRepository = carsManagerRepository;
            _stopPointRepository = stopPointRepository;
            _seatRepository = seatRepository;
            _routeRepository = routeRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
        }

        #region Cars
        /// <summary>
        /// Get Cars
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isIncludeDeleted"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<CarEntity>> GetCars(Expression<Func<CarEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<CarEntity, object>>[] includeProperties)
        {
            return await _carRepository.GetAllAsync(expression, isIncludeDeleted, includeProperties);
        }

        /// <summary>
        /// Get Cars To
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="expression"></param>
        /// <param name="isIncludeDeleted"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<List<T>> GetCarsTo<T>(Func<CarEntity, T> func, Expression<Func<CarEntity, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<CarEntity, object>>[] includeProperties)
        {
            var cars = await _carRepository.GetAllToAsync(func,expression, isIncludeDeleted, includeProperties);

            return cars;
        }

        /// <summary>
        /// Create Car
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> CreateCar(CreateCarModel model)
        {
            var check = model.CarsManagerId != null ?
                await _carsManagerRepository.GetAsync(model.CarsManagerId.Value) != null
                : true;
            if (!check) throw new DomainException(ShareConstant.NotFound, 404);

            var car = new CarEntity(model.ShipPrice, model.TravelPrice, model.CarModel, model.CarColor, model.ImagePath, model.Tel, model.CarNumber, model.ServiceType,model.CarsManagerId);
            await _carRepository.CreateAsync(car);
            await _unitOfWork.SaveChangeAsync();

            return car.Id;
        }

        /// <summary>
        /// Update Car Price
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateCarPrice(UpdateCarPriceModel model)
        {
            var car = await _carRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound,404);

            car.UpdatePrice(model.ShipPrice, model.TravelPrice);
            await _carRepository.UpdateAsync(car);
            await _unitOfWork.SaveChangeAsync();

            return car.Id;
        }

        /// <summary>
        /// Update Car Detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateCarDetail(UpdateCarDetailModel model)
        {
            var car = await _carRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound, 404);

            car.UpdateCarDetail(model.CarModel, model.CarColor,model.ImagePath,model.Tel,model.CarNumber,model.ServiceType);
            await _carRepository.UpdateAsync(car);
            await _unitOfWork.SaveChangeAsync();

            return car.Id;
        }

        /// <summary>
        /// Delete Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCar(Guid id)
        {
            await _carRepository.DeleteAsync(id, true);
            await _unitOfWork.SaveChangeAsync();
        }
        #endregion Cars

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
                    x.Latitude != null && x.Longitude!=null ? 
                        new DetailLocation(x.Longitude,x.Latitude):
                        null)
            ).DistinctBy(x=>x.Location);

            await _stopPointRepository.CreateRangeAsync(points.ToArray());
            await _unitOfWork.SaveChangeAsync();
            return points.Select(x=>x.Id).ToList();
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
            var check = await _carRepository.GetAsync(carid,false,x=>x.StopPoints) ?? throw new DomainException(ShareConstant.NotFound, 404);

            var point = new StopPointEntity(carid, 
                new Location(model.CityId, model.DistrictId, model.WardId, model.Street, model.HouseNumber),
                model.Longitude!=null && model.Latitude!=null ? 
                    new DetailLocation(model.Longitude,model.Latitude)
                    :null);
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
        public async Task<Guid> UpdateStopPointLocation(Guid id,Location model)
        {
            var city = await _cityRepository.GetAsync(model.CityId) ?? throw new DomainException(StoppointConstant.InvalidLocation + "city",400);
            var district = await _districtRepository.GetAsync(model.DistrictId) ?? throw new DomainException(StoppointConstant.InvalidLocation + "district", 400);
            var ward = await _districtRepository.GetAsync(model.WardId) ?? throw new DomainException(StoppointConstant.InvalidLocation + "ward", 400);

            var check = await _stopPointRepository.GetAsync(x=>x.Id== id) ?? throw new DomainException(ShareConstant.NotFound, 400);

            var isNotValid = (await _stopPointRepository.GetAllAsync(x => x.CarId == check.CarId && x.Id != id && x.Location == model)).Any();
            if(isNotValid) new DomainException(StoppointConstant.StoppointExisted, 400);

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

            var isNotValid = (await _stopPointRepository.GetAllAsync(x => x.CarId == check.CarId && x.Id != id && x.DetailLocation == model)).Any();
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
            await _stopPointRepository.DeleteAsync(id,true);
            await _unitOfWork.SaveChangeAsync();
        }
        #endregion

        #region Car seats
        /// <summary>
        /// Create Car Seats
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<List<Guid>> CreateCarSeats(Guid carid, params CreateCarSeatModel[] models)
        {
            var check = await _carRepository.GetAsync(carid) ?? throw new DomainException(ShareConstant.NotFound, 404);

            var seats = models
                .Select(x => new SeatEntity(x.Row, x.Col, carid))
                .Distinct();
            await _seatRepository.CreateRangeAsync(seats.ToArray());
            await _unitOfWork.SaveChangeAsync();
            return seats.Select(x => x.Id).ToList();
        }

        /// <summary>
        /// Create Car Seat
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> CreateCarSeat(Guid carid, CreateCarSeatModel model)
        {
            var check = await _carRepository.GetAsync(carid,false,x=>x.Seats) ?? throw new DomainException(ShareConstant.NotFound, 404);
            if (check.Seats?
                .Where(x => x.Row == model.Row && x.Col == model.Col)
                .Any() ?? false) 
                throw new DomainException(ShareConstant.Existed, 400);

            var seat = new SeatEntity(model.Row, model.Col, carid);
            await _seatRepository.CreateAsync(seat);
            await _unitOfWork.SaveChangeAsync();
            return seat.Id;
        }

        /// <summary>
        /// Update Car Seat Detail
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateCarSeatDetail(Guid carid, UpdateCarSeatDetailModel model)
        {
            var check = await _seatRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound, 404);
            var car = await _carRepository.GetAsync(carid, false, x => x.Seats);
            if (car.Seats?
                .Where(x => x.Row == model.Row && x.Col == model.Col && x.Id != model.Id)
                .Any() ?? false)
                throw new DomainException(SeatContant.SeatExisted, 400);

            check.UpdateSeat(model.Row, model.Col);
            await _seatRepository.UpdateAsync(check);
            await _unitOfWork.SaveChangeAsync();
            return check.Id;
        }

        /// <summary>
        /// Update Car Seat Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="DomainException"></exception>
        public async Task<Guid> UpdateCarSeatStatus(UpdateCarSeatStatusModel model)
        {
            var check = await _seatRepository.GetAsync(model.Id) ?? throw new DomainException(ShareConstant.NotFound, 404);

            if (check.Status != model.Status)
            {
                check.UpdateStatus(model.Status);
                await _seatRepository.UpdateAsync(check);
                await _unitOfWork.SaveChangeAsync();
            }
            return check.Id;
        }

        /// <summary>
        /// Delete Car Seat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCarSeat(Guid id)
        {
            await _seatRepository.DeleteAsync(id,true);
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
        public async Task<List<Guid>> CreateCarRoutes(Guid carid,params CreateCarRouteModel[] models)
        {
            var check = await _carRepository.GetAsync(carid) ?? throw new DomainException(ShareConstant.NotFound, 404);

            var routes = models.Select(x=>new RouteEntity(carid,x.FromId,x.ToId,x.DistanceByKm,x.Day,x.Hour,x.Minute)).DistinctBy(x=>new {from=x.FromId,to=x.ToId}).ToArray();
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
            var check = await _carRepository.GetAsync(carid,false,x=>x.Routes) ?? throw new DomainException(ShareConstant.NotFound, 404);
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
        public async Task<Guid> UpdateCarRoute(Guid id,UpdateCarRouteModel model)
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
