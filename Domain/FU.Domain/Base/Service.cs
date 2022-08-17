using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Base
{
    public abstract class Service
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
