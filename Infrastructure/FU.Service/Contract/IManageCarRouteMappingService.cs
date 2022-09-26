using FU.Domain.Entities.CarRouteMapping.SubModel;
using FU.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Contract
{
    public interface IManageCarRouteMappingService
    {
        Task<CarRouteMappingInfoModel> GetCarRouteMappingDetailAsync(Guid id);
        Task<List<CarRouteMappingInfoModel>> GetCarRouteMappingDetailsAsync();
        Task<Guid> UpdateCarRouteMappingDetailAsync(UpdateCarRouteMappingStarttimeModel model);
        Task<Guid> CreateCarRouteMappingDetailAsync(CreateCarRouteMappingStarttimeModel model);
        Task DeleteCarRouteMappingAsync(Guid id);
    }
}
