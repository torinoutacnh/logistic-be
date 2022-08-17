using FU.Domain.Base;
using FU.Infras.CustomAttribute;
using FU.Repository.DbStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Base
{
    [RegisterScope]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Store _store;

        public UnitOfWork(Store store)
        {
            _store = store;
        }

        public int SaveChange()
        {
            return _store.SaveChanges();
        }

        public Task<int> SaveChangeAsync()
        {
            return _store.SaveChangesAsync();
        }
    }
}
