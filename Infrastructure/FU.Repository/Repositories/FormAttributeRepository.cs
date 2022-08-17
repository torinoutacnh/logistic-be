using FU.Domain.Entities.Form;
using FU.Domain.Entities.FormAttribute;
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
    public class FormAttributeRepository : Repository<FormAttributeEntity>, IFormAttributeRepository
    {
        public FormAttributeRepository(Store store) : base(store)
        {
        }
    }
}
