using FU.Domain.Entities.Ticket;
using FU.Infras.CustomAttribute;
using FU.Repository.Base;
using FU.Repository.DbStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Repositories
{
    [RegisterScope]
    public class TicketRepository : Repository<TicketEntity>, ITicketRepository
    {
        public TicketRepository(Store store) : base(store)
        {
        }

        public Task<List<TicketViewModel>> GetAllTickets()
        {
            var query = from ticket in _store.Tickets
                        where ticket.IsDeleted == false
                        select new TicketViewModel(ticket);
            return query.ToListAsync();
        }

        public Task<TicketViewModel> GetTicketById(Guid id)
        {
            var query = from ticket in _store.Tickets
                        where ticket.IsDeleted == false && ticket.Id == id
                        select new TicketViewModel(ticket);
            return query.FirstOrDefaultAsync();
        }
    }
}
