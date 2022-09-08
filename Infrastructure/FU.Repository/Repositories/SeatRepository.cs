using FU.Domain.Base;
using FU.Domain.Entities.Car;
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
    public class SeatRepository : Repository<SeatEntity>, ISeatRepository
    {
        public SeatRepository(Store store) : base(store)
        {
        }
    }
}
