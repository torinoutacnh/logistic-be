using FU.Domain.Entities.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Service.Contract
{
    public  interface IManageTicketService
    {
        Task<List<TicketViewModel>> GetTicketListAsync();
        Task<TicketViewModel> GetTicketAsync(Guid id);
        Task<Guid> CreateTicketAsync(CreateTicketModel model);
        Task<Guid> UpdateTicketAsync(UpdateTicketSeatModel model);
        Task<Guid> UpdateTicketMappingAsync(UpdateTicketMappingModel model);
        Task DeleteTicketAsync(Guid id);
    }
}
