using FU.Domain.Entities.Ticket;
using FU.Infras.CustomAttribute;
using FU.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace FU.Service
{
    [RegisterTransient]
    public class ManageTicketService : IManageTicketService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public ManageTicketService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger>();
        }
        public async Task<List<TicketViewModel>> GetTicketListAsync()
        {
            try
            {
                _logger.Information("Start get ticket list");
                var service = _serviceProvider.GetRequiredService<TicketDomainService>();
                
                var tickets =  await service.GetTicketList();
                return tickets;
            }
            catch (Exception)
            {
                _logger.Information("Error on get tickets");
                throw;
            }
            finally
            {
                _logger.Information("Finish get ticket list");
            }
        }
        public async Task<TicketViewModel> GetTicketAsync(Guid id)
        {
            try
            {
                _logger.Information("Start get ticket by id");
                var service = _serviceProvider.GetRequiredService<TicketDomainService>();

                var ticket = await service.GetTicket(id);
                return ticket;
            }
            catch (Exception)
            {
                _logger.Information("Error on get ticket by id");
                throw;
            }
            finally
            {
                _logger.Information("Finish get ticket by id");
            }
        }

        public async Task<Guid> CreateTicketAsync(CreateTicketModel model)
        {
            try
            {
                _logger.Information("Start create ticket");
                var service = _serviceProvider.GetRequiredService<TicketDomainService>();

                var ticket = await service.CreateTicket(model);
                return ticket;
            }
            catch (Exception)
            {
                _logger.Information("Error create ticket");
                throw;
            }
            finally
            {
                _logger.Information("Finish create ticket");
            }
        }

        public async Task<Guid> UpdateTicketAsync(UpdateTicketSeatModel model)
        {
            try
            {
                _logger.Information("Start update ticket seat and item");
                var service = _serviceProvider.GetRequiredService<TicketDomainService>();

                var ticket = await service.UpdateTicketSeat(model);
                return ticket;
            }
            catch (Exception)
            {
                _logger.Information("Error on update ticket seat and item");
                throw;
            }
            finally
            {
                _logger.Information("Finish update ticket seat and item");
            }
        }
        public async Task<Guid> UpdateTicketMappingAsync(UpdateTicketMappingModel model)
        {
            try
            {
                _logger.Information("Start update ticket mapping");
                var service = _serviceProvider.GetRequiredService<TicketDomainService>();

                var ticket = await service.UpdateTicketMapping(model);
                return ticket;
            }
            catch (Exception)
            {
                _logger.Information("Error on update ticket mapping");
                throw;
            }
            finally
            {
                _logger.Information("Finish update ticket mapping");
            }
        }

        public async Task DeleteTicketAsync(Guid id)
        {
            try
            {
                _logger.Information("Start delete ticket");
                var service = _serviceProvider.GetRequiredService<TicketDomainService>();

                await service.DeleteTicket(id);
            }
            catch (Exception)
            {
                _logger.Information("Error on delete ticket");
                throw;
            }
            finally
            {
                _logger.Information("Finish delete ticket");
            }
        }

    }
}
