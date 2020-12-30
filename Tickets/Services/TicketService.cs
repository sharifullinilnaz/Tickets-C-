using Tickets.Data;
using Tickets.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Tickets.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketsDbContext _ticketsDbContext;

        public TicketService(TicketsDbContext ticketsDbContext)
        {
            _ticketsDbContext = ticketsDbContext ?? throw new ArgumentNullException(nameof(ticketsDbContext));
        }

        public async Task<TicketDto[]> Get(int id)
        {
            var judges = await _ticketsDbContext.Tickets
                .Where(x => x.EventId.HasValue)
                .ToArrayAsync();

            var ticketsDtos = new List<TicketDto>();
            foreach(var j in judges)
            {
                ticketsDtos.Add(new TicketDto
                {
                    EventName = j.Event.Name
                });
            }

            return await _ticketsDbContext.Tickets
                .Where(x => x.Event.Name == "Нефтехимик - АкБарс")
                .Select(x => new TicketDto
                {
                    Id = x.Id,
                    Place = x.Place,
                    Price = x.Price,
                    Time = x.Time,
                    Stadium = x.Stadium,
                    EventId = x.EventId,
                    EventName = x.Event.Name
                })
                .ToArrayAsync();
        }

        public async Task<int> Create(TicketDto ticketDto)
        {
            Ticket ticket = new Ticket();

            AplyDtoToEntity(ticket, ticketDto);

            _ticketsDbContext.Tickets.Add(ticket);
            await _ticketsDbContext.SaveChangesAsync();

            return ticket.Id;
        }

        public async Task<int> Update(TicketDto ticketDto)
        {
            Ticket ticket = _ticketsDbContext.Tickets.Find(ticketDto.Id);

            AplyDtoToEntity(ticket, ticketDto);

            await _ticketsDbContext.SaveChangesAsync();

            return ticket.Id;
        }

        public async Task Delete(int id)
        {
            Ticket ticket = _ticketsDbContext.Tickets.Find(id);

            _ticketsDbContext.Tickets.Remove(ticket);
            await _ticketsDbContext.SaveChangesAsync();
        }

        private void AplyDtoToEntity(Ticket ticket, TicketDto ticketDto)
        {
            ticket.Place = ticketDto.Place;
            ticket.Price = ticketDto.Price;
            ticket.Time = ticketDto.Time;
            ticket.Stadium = ticketDto.Stadium;
            ticket.EventId = ticketDto.EventId;

        }
    }
}
