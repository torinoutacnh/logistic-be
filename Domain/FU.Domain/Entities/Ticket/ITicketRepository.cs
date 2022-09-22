using FU.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Entities.Ticket
{
    public interface ITicketRepository:IRepository<TicketEntity>
    {
        //public string MyProperty { get; set; }
    }
}
