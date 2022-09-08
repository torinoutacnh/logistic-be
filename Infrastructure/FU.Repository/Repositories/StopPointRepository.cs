using FU.Domain.Entities.StopPoint;
using FU.Infras.CustomAttribute;
using FU.Repository.Base;
using FU.Repository.DbStore;
using FU.Repository.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Repositories
{
    [RegisterScope]
    public class StopPointRepository : Repository<StopPointEntity>, IStopPointRepository
    {
        public StopPointRepository(Store store) : base(store)
        {
        }
    }
}
