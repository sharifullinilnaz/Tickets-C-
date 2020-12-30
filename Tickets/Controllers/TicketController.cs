using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data.Models;
using Tickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tickets.Controllers
{
    [Route("Ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Получение билета по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор билета.</param>
        /// <returns>Модель билета.</returns>
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var ticketDto = await _ticketService.Get(id);
            return Ok(new { Success = true, Ticket = ticketDto });
        }

        /// <summary>
        /// Добавление билета.
        /// </summary>
        /// <param name="ticketDto">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного билета.</returns>
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(TicketDto ticketDto)
        {
            return Ok(new { Success = true, TicketId = await _ticketService.Create(ticketDto) });
        }

        /// <summary>
        /// Обновление билета.
        /// </summary>
        /// <param name="ticketDto">Модель для обновления.</param>
        /// <returns>Идентификатор обновленного билета.</returns>
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(TicketDto ticketDto)
        {
            return Ok(new { Success = true, TicketId = await _ticketService.Update(ticketDto) });
        }

        /// <summary>
        /// Удаление билета.
        /// </summary>
        /// <param name="id">Модель для удаления.</param>
        [HttpPost]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ticketService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}
