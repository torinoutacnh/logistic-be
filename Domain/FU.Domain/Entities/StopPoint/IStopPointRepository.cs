using FU.Domain.Base;
using FU.Domain.Entities.StopPoint.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.StopPoint
{
    public interface IStopPointRepository:IRepository<StopPointEntity>
    {
        Task<StopPointModel?> GetStopPointDetail(Guid pointId);
        bool ValidateLocation(Location model);
    }
}
