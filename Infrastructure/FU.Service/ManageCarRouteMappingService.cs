using FU.Domain.Entities.CarRouteMapping.SubModel;
using FU.Infras.CustomAttribute;
using FU.Service.Contract;
using FU.Service.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        public Task<CarRouteMappingInfoModel> GetCarRouteMappingDetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CarRouteMappingInfoModel>> GetCarrouteMappingDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateCarRouteMappingDetailAsync(UpdateCarRouteMappingWithFileModel model)
        {
            throw new NotImplementedException();
        }
    }
}
