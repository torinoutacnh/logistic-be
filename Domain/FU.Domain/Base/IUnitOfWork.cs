using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Base
{
    public interface IUnitOfWork
    {
        int SaveChange();
        Task<int> SaveChangeAsync();
    }
}
