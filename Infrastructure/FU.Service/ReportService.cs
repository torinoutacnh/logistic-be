using FU.Domain.Base;
using FU.Domain.Entities.Form;
using FU.Domain.Entities.FormAttribute;
using FU.Infras.CustomAttribute;
using FU.Infras.Utils;
using FU.Service.Contract;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;

namespace FU.Service
{
    [RegisterTransient]
    public class ReportService: IReportService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public ReportService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger>();
        }

        /// <summary>
        /// Get form model from db
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<FormEntity?> GetForm(string code)
        {
            try
            {
                _logger.Information("Start get form");

                return _serviceProvider
                .GetRequiredService<IFormRepository>()
                .GetAsync(x => x.Info.Code == code, false, x => x.Attributes);
            }
            catch(Exception ex)
            {
                _logger.Information($"Error get form : {ex.Message}");
                throw ex;
            }
            finally
            {
                _logger.Information("Finish get form");
            }
        }

        /// <summary>
        /// Create form with default attributes
        /// </summary>
        /// <param name="info"></param>
        /// <param name="labels"></param>
        /// <returns></returns>
        public Task CreateForm(FormInfo info, string[] labels)
        {
            try
            {
                _logger.Information("Start create form");

                var formService = _serviceProvider.GetRequiredService<FormDomainService>();
                return formService.Create(info, labels);
            }
            catch (Exception ex)
            {
                _logger.Information($"Error get form : {ex.Message}");
                throw ex;
            }
            finally
            {
                _logger.Information("Finish get form");
            }
        }

        /// <summary>
        /// Update form info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFormInfo(string id, FormInfo info)
        {
            try
            {
                _logger.Information("Start create form");

                var formService = _serviceProvider.GetRequiredService<FormDomainService>();
                await formService.UpdateInfo(id, info);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Information($"Error get form : {ex.Message}");
                throw ex;
            }
            finally
            {
                _logger.Information("Finish get form");
            }
        }

        /// <summary>
        /// Delete form by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPhysical"></param>
        /// <returns></returns>
        public async Task DeleteForm(string id,bool isPhysical = false)
        {
            try
            {
                _logger.Information("Start create form");

                var formService = _serviceProvider.GetRequiredService<FormDomainService>();
                await formService.Delete(id, isPhysical);
            }
            catch (Exception ex)
            {
                _logger.Information($"Error get form : {ex.Message}");
                throw ex;
            }
            finally
            {
                _logger.Information("Finish get form");
            }
        }
    }
}