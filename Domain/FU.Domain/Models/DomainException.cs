using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Models
{
    public class DomainException:Exception
    {
        public int Code { get; set; }
        public DomainException(string message,int code = 400):base(message)
        {
            Code = code;
        }
    }
}
