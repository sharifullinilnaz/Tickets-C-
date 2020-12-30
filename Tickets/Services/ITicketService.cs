using Tickets.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Services
{
    public interface ITicketService
    {
        Task<TicketDto[]> Get(int id);

        Task<int> Create(TicketDto ticketDto);

        Task<int> Update(TicketDto ticketDto);

        Task Delete(int id);
    }
}