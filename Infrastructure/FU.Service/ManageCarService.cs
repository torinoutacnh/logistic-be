using AutoMapper;
using FU.Domain.Base;
using FU.Domain.Constant;
using FU.Domain.Entities.Car;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.CarsManager.SubModel;
using FU.Infras.CustomAttribute;
using FU.Infras.Utils;
using FU.Service.Contract;
using FU.Service.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        #region private
        private string? CheckFile(IFormFile? file)
        {
            if (file == null) return null;
            if (file.FileName.HasImageExtension())
            {
                var ext = file.FileName.Split(".").LastOrDefault();
                var newName = Guid.NewGuid().ToString("N");
                return $"{newName}.{ext}";
            }
            return null;
        }
        private void ClearDir(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }
        }
        private Task<string> SaveFileAsync(IFormFile? file)
        {
            var enviroment = _serviceProvider.GetRequiredService<IWebHostEnvironment>();
            string wwwPath = enviroment.WebRootPath;
            //string contentPath = enviroment.ContentRootPath;

            string path = Path.Combine(wwwPath,
                FileConstant.Base,
                FileConstant.CarManager);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filepath = CheckFile(file);
            if (filepath != null)
                using (FileStream stream = new FileStream(Path.Combine(path, filepath), FileMode.Create))
                {
                    file?.CopyTo(stream);
                    return Task.FromResult($"/{FileConstant.Base}/{FileConstant.CarManager}/{filepath}");
                }

            return Task.FromResult("");
        }
        private Task<string> SaveCarFileAsync(IFormFile? file)
        {
            var enviroment = _serviceProvider.GetRequiredService<IWebHostEnvironment>();
            string wwwPath = enviroment.WebRootPath;
            //string contentPath = enviroment.ContentRootPath;

            string path = Path.Combine(wwwPath,
                FileConstant.Base,
                FileConstant.Car);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filepath = CheckFile(file);
            if (filepath != null)
                using (FileStream stream = new FileStream(Path.Combine(path, filepath), FileMode.Create))
                {
                    file?.CopyTo(stream);
                    return Task.FromResult($"/{FileConstant.Base}/{FileConstant.Car}/{filepath}");
                }

            return Task.FromResult("");
        }
        #endregion

        #region Car manager
        /// <summary>
        /// Get Manager Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarsManagerInfoModel?> GetManagerAsync(Guid id)
        {
            try
            {
                _logger.Information("Start get manager");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();

                var manager = await service.GetCarsManagerById(id);
                return manager;
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
        public async Task<List<CarsManagerViewModel>?> GetManagersAsync()
        {
            try
            {
                _logger.Information("Start get managers");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();
                var mapper = _serviceProvider.GetRequiredService<IMapper>();

                var managers = await service.GetCarsManagers(x => true);
                return managers.ToList();
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
        public async Task<Guid> CreateManager(CreateManagerModel model)
        {
            try
            {
                _logger.Information("Start create manager");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();
                var filepath = await SaveFileAsync(model.LogoPath);
                var cre = new CreateCarsManagerModel() { 
                    LogoPath = filepath,
                    Name = model.Name,
                    Description = model.Description,
                };
                var id = await service.CreateManager(cre);
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
        public async Task<Guid> UpdateManager(UpdateManagerModel model)
        {
            try
            {
                _logger.Information("Start update manager");
                var service = _serviceProvider.GetRequiredService<CarsManagerDomainService>();
                var newFilePath = await SaveFileAsync(model.LogoPath);
                var update = new UpdateCarsManagerModel()
                {
                    Id = model.Id,
                    LogoPath = newFilePath,
                    Description = model.Description,
                    Name = model.Name
                };

                var id = await service.UpdateManager(update);
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
        /// Get Car List Async
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public async Task<List<CarViewModel>> GetCarListAsync()
        {
            try
            {
                _logger.Information("Start get car list");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var car = (await service.GetCars(x => true,false,x=>x.CarsManager))
                    .Select(x => new CarViewModel(x))
                    .ToList();
                return car;
            }
            catch (Exception)
            {
                _logger.Information("Error get car list");
                throw;
            }
            finally
            {
                _logger.Information("Finish get car list");
            }
        }

        /// <summary>
        /// Get Car By Manager Async
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public async Task<List<CarViewModel>> GetCarByManagerAsync(Guid managerId)
        {
            try
            {
                _logger.Information("Start get car by manager");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var car = (await service.GetCars(x => x.CarsManagerId == managerId, false, x => x.CarsManager))
                    .Select(x=>new CarViewModel(x))
                    .ToList();
                return car;
            }
            catch (Exception)
            {
                _logger.Information("Error get car by manager");
                throw;
            }
            finally
            {
                _logger.Information("Finish get car by manager");
            }
        }

        /// <summary>
        /// Get Car Detail Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarInfoModel> GetCarDetailAsync(Guid id)
        {
            try
            {
                _logger.Information("Start get car");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var car = await service.GetCarDetail(id);
                return car;
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
        public async Task<List<CarInfoModel>> GetCarDetailsAsync()
        {
            try
            {
                _logger.Information("Start get cars");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var cars = await service.GetCarDetails();
                return cars;
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
        public async Task<Guid> CreateCarAsync(CreateCarWithFileModel model)
        {
            try
            {
                _logger.Information("Start create car");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();
                var filepath = await SaveCarFileAsync(model.ImagePath);
                var cre = new CreateCarModel(model.ShipPrice, 
                    model.TravelPrice, 
                    model.CarColor, 
                    model.Tel, filepath, 
                    model.Tel, 
                    model.CarNumber, 
                    model.ServiceType, 
                    model.CarsManagerId);
                var car = await service.CreateCar(cre);
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
        public async Task<Guid> UpdateCarDetailAsync(UpdateCarDetailWithFileModel model)
        {
            try
            {
                _logger.Information("Start update car detail");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();
                var filepath = await SaveCarFileAsync(model.ImagePath);
                var update = new UpdateCarDetailModel(model.Id,
                    model.CarModel,
                    model.CarColor,
                    filepath,
                    model.Tel,
                    model.CarNumber,
                    model.ServiceType);
                var car = await service.UpdateCarDetail(update);
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

        public async Task<List<CarInfoModel>> GetCarByLocationStarttimeAsync(Guid FromCityId, Guid ToCityId, DateTimeOffset Starttime)
        {
            try
            {
                _logger.Information("Start get cars");
                var service = _serviceProvider.GetRequiredService<CarDomainService>();

                var cars = await service.GetCarsByLocationStarttime(FromCityId, ToCityId, Starttime);
                return cars;
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
        #endregion
    }
}