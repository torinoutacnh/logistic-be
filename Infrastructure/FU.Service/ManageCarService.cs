using AutoMapper;
using FU.Domain.Base;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.CarsManager.SubModel;
using FU.Infras.CustomAttribute;
using FU.Infras.Utils;
using FU.Service.Contract;
using FU.Service.Models.Car;
using FU.Service.Models.CarsManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;

namespace FU.Service
{
    [RegisterTransient]
    public class ManageCarService: IManageCarService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public ManageCarService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger>();
        }

        #region Car manager
        /// <summary>
        /// Get Manager Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarsManagerMapModel?> GetManagerAsync(Guid id)
        {
            try
            {
                _logger.Information("Start get manager");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();
                var mapper = _serviceProvider.GetRequiredService<IMapper>();

                var manager = await service.GetCarsManagerById(id);
                var info = mapper.Map<CarsManagerMapModel>(manager);
                return info;
            }
            catch (Exception ex)
            {
                _logger.Information($"Error get manager : {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish get manager");
            }
        }

        /// <summary>
        /// Get Managers Async
        /// </summary>
        /// <returns></returns>
        public async Task<List<CarsManagerInfoModel>?> GetManagersAsync()
        {
            try
            {
                _logger.Information("Start get managers");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();
                var mapper = _serviceProvider.GetRequiredService<IMapper>();

                var managers = await service.GetCarsManagers(x => true) ?? new List<CarsManagerEntity>();
                var info = mapper.ProjectTo<CarsManagerInfoModel>(managers.AsQueryable());
                return info.ToList();
            }
            catch (Exception ex)
            {
                _logger.Information($"Error get managers : {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish get managers");
            }
        }

        /// <summary>
        /// Create Manager
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateManager(CreateCarsManagerModel model)
        {
            try
            {
                _logger.Information("Start create manager");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();

                var id = await service.CreateManager(model);
                return id;
            }
            catch (Exception ex)
            {
                _logger.Information($"Error create manager : {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish create manager");
            }
        }

        /// <summary>
        /// Update Manager
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateManager(UpdateCarsManagerModel model)
        {
            try
            {
                _logger.Information("Start update manager");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();

                var id = await service.UpdateManager(model);
                return id;
            }
            catch (Exception ex)
            {
                _logger.Information($"Error update manager : {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish update manager");
            }
        }

        /// <summary>
        /// Delete Manager
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteManager(Guid id)
        {
            try
            {
                _logger.Information("Start delete manager");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();

                await service.DeleteManager(id);
            }
            catch (Exception ex)
            {
                _logger.Information($"Error delete manager : {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish delete manager");
            }
        }
        #endregion

        #region Car
        /// <summary>
        /// Get Car Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarMapModel> GetCarAsync(Guid id)
        {
            try
            {
                _logger.Information("Start get car");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();
                var mapper = _serviceProvider.GetRequiredService<IMapper>();

                var car = await service.GetCar(id);
                var carMap = mapper.Map<CarMapModel>(car);
                return carMap;
            }
            catch (Exception)
            {
                _logger.Information("Error get car");
                throw;
            }
            finally
            {
                _logger.Information("Finish get car");
            }
        }

        /// <summary>
        /// Get Cars Async
        /// </summary>
        /// <returns></returns>
        public async Task<List<CarInfoModel>> GetCarsAsync()
        {
            try
            {
                _logger.Information("Start get cars");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();
                var mapper = _serviceProvider.GetRequiredService<IMapper>();

                var cars = await service.GetCars(x => true);
                var carMap = mapper.ProjectTo<CarInfoModel>(cars.AsQueryable());
                    //cars.Select(x => mapper.Map<CarInfoModel>(x));
                return carMap.ToList();
            }
            catch (Exception)
            {
                _logger.Information("Error get cars");
                throw;
            }
            finally
            {
                _logger.Information("Finish get cars");
            }
        }

        /// <summary>
        /// Create Car Async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateCarAsync(CreateCarModel model)
        {
            try
            {
                _logger.Information("Start create car");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var car = await service.CreateCar(model);
                return car;
            }
            catch (Exception)
            {
                _logger.Information("Error create car");
                throw;
            }
            finally
            {
                _logger.Information("Finish create car");
            }
        }

        /// <summary>
        /// Update Car Detail Async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateCarDetailAsync(UpdateCarDetailModel model)
        {
            try
            {
                _logger.Information("Start update car detail");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var car = await service.UpdateCarDetail(model);
                return car;
            }
            catch (Exception)
            {
                _logger.Information("Error update car detail");
                throw;
            }
            finally
            {
                _logger.Information("Finish update car detail");
            }
        }

        /// <summary>
        /// Update Car Price Async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateCarPriceAsync(UpdateCarPriceModel model)
        {
            try
            {
                _logger.Information("Start update car price");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var car = await service.UpdateCarPrice(model);
                return car;
            }
            catch (Exception)
            {
                _logger.Information("Error update car price");
                throw;
            }
            finally
            {
                _logger.Information("Finish update car price");
            }
        }

        /// <summary>
        /// Delete Car Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCarAsync(Guid id)
        {
            try
            {
                _logger.Information("Start update car price");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                await service.DeleteCar(id);
            }
            catch (Exception)
            {
                _logger.Information("Error update car price");
                throw;
            }
            finally
            {
                _logger.Information("Finish update car price");
            }
        }
        #endregion
    }
}