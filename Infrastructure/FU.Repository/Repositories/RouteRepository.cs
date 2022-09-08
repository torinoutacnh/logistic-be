using FU.Domain.Entities.Route;
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
    public class RouteRepository : Repository<RouteEntity>, IRouteRepository
    {
        public RouteRepository(Store store) : base(store)
        {
        }
    }
}
