using FU.Domain.Base;
using FU.Domain.Entities.CarRouteMapping.SubModel;
using FU.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.CarRouteMapping
{
    public interface ICarRouteMappingRepository:IRepository<CarRouteMappingEntity>
    {
        Task<CarRouteMappingInfoModel?> GetCarRouteMappingInfo(Guid id);
        Task<List<CarRouteMappingInfoModel>> GetCarRouteMappingInfos();
    }
}
