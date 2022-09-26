using AutoMapper;
using FU.Domain.Constant;
using FU.Domain.Entities.CarRouteMapping;
using FU.Domain.Entities.CarRouteMapping.SubModel;
using FU.Infras.CustomAttribute;
using FU.Service.Contract;
using FU.Service.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service
{
    [RegisterTransient]


    public class ManageCarRouteMappingService : IManageCarRouteMappingService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public ManageCarRouteMappingService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger>();
        }


        public async Task<CarRouteMappingInfoModel> GetCarRouteMappingDetailAsync(Guid id)
        {
            try
            {
                _logger.Information("Start new CarRoutMapping");
                var service = _serviceProvider.GetRequiredService<CarRouteMappingDomainService>();
                
                var carRouteMapping = await service.GetCarRouteMappingDetail(id);
                return carRouteMapping;
            }
            catch (Exception ex)
            {
                _logger.Information($"Error get CarRouteMapping : {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish get CarRouteMapping");
            }
        }

        public async Task<List<CarRouteMappingInfoModel>> GetCarRouteMappingDetailsAsync()
        {
            try
            {
                _logger.Information("Start get CarRouteMappings");
                var service = _serviceProvider.GetRequiredService<CarRouteMappingDomainService>();

                var managers = await service.GetCarRouteMappingDetails();
                return managers.ToList();
            }
            catch (Exception ex)
            {
                _logger.Information($"Error get CarRouteMapping: {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish get CarRouteMapping");
            }
        }


        public async Task<Guid> UpdateCarRouteMappingDetailAsync(UpdateCarRouteMappingStarttimeModel model)
        {
            try
            {
                _logger.Information("Start update carRouteMapping");
                var service = _serviceProvider.GetRequiredService<CarRouteMappingDomainService>();
                var update = new UpdateCarRouteMappingStarttimeModel(model.CarId,
                    model.RouteId,
                    model.Starttime);
                var starttime = await service.UpdateCarRouteMappingStarttime(update);
                return starttime;
            }
            catch (Exception)
            {
                _logger.Information("Error update Start time");
                throw;
            }
            finally
            {
                _logger.Information("finish update Start time");
            }
        }
        public async Task<Guid> CreateCarRouteMappingDetailAsync(CreateCarRouteMappingStarttimeModel model)
        {
            try
            {
                _logger.Information("Start create Start time");
                var service = _serviceProvider.GetRequiredService<CarRouteMappingDomainService>();
                var cre = new CreateCarRouteMappingStarttimeModel()
                {
                    CarId = model.CarId,
                    RouteId = model.RouteId,
                    Starttime = model.Starttime,
                };
                var id = await service.CreateCarRouteMappingStarttime(cre);
                return id;
            }
            catch (Exception ex)
            {
                _logger.Information($"Error create Start time : {ex.Message}");
                throw;
            }
            finally
            {
                _logger.Information("Finish create Start time");
            }
        }
    }
}
