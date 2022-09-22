using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.LocalLocation;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.Seat;
using FU.Domain.Entities.Seat.SubModel;
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
        private readonly ISeatRepository _seatRepository;

        public CarDomainService(IUnitOfWork unitOfWork, 
            ICarRepository carRepository,
            ICarsManagerRepository carsManagerRepository, 
            ISeatRepository seatRepository) : base(unitOfWork)
        {
            _carRepository = carRepository;
            _carsManagerRepository = carsManagerRepository;
            _seatRepository = seatRepository;
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
            var cars = await _carRepository.GetAllAsync(expression, isIncludeDeleted, includeProperties);
            return cars;
        }

        /// <summary>
        /// Get Car Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarInfoModel> GetCarDetail(Guid id)
        {
            var car = await _carRepository.GetCarInfo(id);
            return car;
        }

        /// <summary>
        /// Get Car Details
        /// </summary>
        /// <returns></returns>
        public async Task<List<CarInfoModel>> GetCarDetails()
        {
            var car = await _carRepository.GetCarInfos();
            return car;
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
        /// Get Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarEntity?> GetCar(Guid id)
        {
            return await _carRepository.GetAsync(id,false,x=>x.Seats);
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
            var isCar = await _carRepository.GetAsync(x=>x.CarNumber == model.CarNumber);
            if(isCar!=null) throw new DomainException(CarConstant.NumberExisted, 400);

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
            await _carRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangeAsync();
        }
        #endregion Cars

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
                .Select(x => new SeatEntity(x.Row, x.Col, x.Floor, carid))
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

            var seat = new SeatEntity(model.Row, model.Col, model.Floor, carid);
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

            check.UpdateSeat(model.Row, model.Col, model.Floor);
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
            await _seatRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangeAsync();
        }
        #endregion
    }
}
