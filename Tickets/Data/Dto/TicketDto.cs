using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Data.Models
{
    /// <summary>
    /// Билет.
    /// </summary>
    public class TicketDto
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Место
        /// </summary>
        public int Place { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Идентификатор вида спорта.
        /// </summary>
        public int? EventId { get; set; }

        /// <summary>
        /// Вид Спорта.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Время
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Стадион
        /// </summary>
        public string Stadium { get; set; }
    }
}
