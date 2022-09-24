using FU.Domain.Entities.CarRouteMapping;
using FU.Domain.Entities.CarRouteMapping.SubModel;
using FU.Domain.Entities.Mapping;
using FU.Infras.CustomAttribute;
using FU.Repository.Base;
using FU.Repository.DbStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Repositories
{
    [RegisterScope]
    public class CarRouteMappingRepository : Repository<CarRouteMappingEntity>, ICarRouteMappingRepository
    {
        public CarRouteMappingRepository(Store store) : base(store)
        {
        }

        public Task<CarRouteMappingInfoModel?> GetCarRouteMappingInfo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CarRouteMappingInfoModel>> GetCarRouteMappingInfos()
        {
            throw new NotImplementedException();
        }
    }
}
