using FU.Domain.Entities.CarsManager;
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
    public class CarsManagerRepository : Repository<CarsManagerEntity>, ICarsManagerRepository
    {
        public CarsManagerRepository(Store store) : base(store)
        {
        }
    }
}
