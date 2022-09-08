using FU.Domain.Base;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.CarsManager.SubModel;
using FU.Infras.CustomAttribute;
using FU.Infras.Utils;
using FU.Service.Contract;
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
    }
}