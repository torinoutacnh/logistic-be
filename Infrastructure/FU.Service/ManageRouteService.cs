using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.Car;
using FU.Infras.CustomAttribute;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.StopPoint;
using FU.Service.Contract;
using System.Drawing;
using FU.Domain.Entities.LocalLocation.SubModel;

namespace FU.Service
{
    [RegisterTransient]
    public class ManageRouteService: IManageRouteService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public ManageRouteService(IServiceProvider serviceProvider, ILogger logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        #region city, district, ward
        /// <summary>
        /// Get Cities
        /// </summary>
        /// <returns></returns>
        public async Task<List<CityViewModel>> GetCitiesAsync()
        {
            try
            {
                _logger.Information("Start get cities");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var cities = await service.GetCities();
                return cities;
            }
            catch (Exception)
            {
                _logger.Information("Error get cities");
                throw;
            }
            finally
            {
                _logger.Information("Finish get cities");
            }
        }

        /// <summary>
        /// Get Districts By City
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<DistrictViewModel>> GetDistrictsByCityAsync(Guid id)
        {
            try
            {
                _logger.Information("Start get districts");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var districts = await service.GetDistrictsFromCity(id);
                return districts;
            }
            catch (Exception)
            {
                _logger.Information("Error get districts");
                throw;
            }
            finally
            {
                _logger.Information("Finish get districts");
            }
        }

        /// <summary>
        /// Get Wards By District
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<WardViewModel>> GetWardsByDistrictAsync(Guid id)
        {
            try
            {
                _logger.Information("Start get wards");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var wards = await service.GetWardsFromDistrict(id);
                return wards;
            }
            catch (Exception)
            {
                _logger.Information("Error get wards");
                throw;
            }
            finally
            {
                _logger.Information("Finish get wards");
            }
        }
        #endregion

        #region stop point
        /// <summary>
        /// Create Stop Point
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateStopPoint(Guid carid,CreateStopPointModel model)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var point = await service.CreateStopPoint(carid, model);
                return point;
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }

        /// <summary>
        /// Create Stop Points
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<List<Guid>> CreateStopPoints(Guid carid, ICollection<CreateStopPointModel> models)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var points = await service.CreateStopPoints(carid, models);
                return points;
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }

        /// <summary>
        /// Update Stop Point Location
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateStopPointLocation(Guid carid, Location model)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var point = await service.UpdateStopPointLocation(carid, model);
                return point;
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }

        /// <summary>
        /// Update Stop Point Detail Location
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateStopPointDetailLocation(Guid carid, DetailLocation model)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var point = await service.UpdateStopPointDetailLocation(carid, model);
                return point;
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }

        /// <summary>
        /// Delete Stop Point
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteStopPoint(Guid id)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                await service.DeleteStopPoint(id);
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }
        #endregion

        #region route
        /// <summary>
        /// Create Route
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> CreateRoute(Guid carid, CreateCarRouteModel model)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var routeid = await service.CreateCarRoute(carid, model);
                return routeid;
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }

        /// <summary>
        /// Create Routes
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<List<Guid>> CreateRoutes(Guid carid, params CreateCarRouteModel[] models)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var routeid = await service.CreateCarRoutes(carid, models);
                return routeid;
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }

        /// <summary>
        /// Update Route
        /// </summary>
        /// <param name="carid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> UpdateRoute(Guid carid, UpdateCarRouteModel model)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                var routeid = await service.UpdateCarRoute(carid, model);
                return routeid;
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }

        /// <summary>
        /// Delete Route
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteRoute(Guid id)
        {
            try
            {
                _logger.Information("Start create stop point");
                var service = _serviceProvider.GetRequiredService<ManageCarRouteDomainService>();

                await service.DeleteCarRoute(id);
            }
            catch (Exception)
            {
                _logger.Information("Error create stop point");
                throw;
            }
            finally
            {
                _logger.Information("Finish create stop point");
            }
        }
        #endregion
    }
}
