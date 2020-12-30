using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Data.Models
{
    /// <summary>
    /// Судья.
    /// </summary>
    [Table("tickets")]
    public class Ticket
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Стадион
        /// </summary>
        [Column("stadium", TypeName = "varchar(150)")]
        public string Stadium { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        [Column("price", TypeName = "integer")]
        public int Price { get; set; }

        /// <summary>
        /// Место
        /// </summary>
        [Column("place", TypeName = "integer")]
        public int Place { get; set; }

        /// <summary>
        /// Время
        /// </summary>
        [Column("time", TypeName = "time")]
        public DateTime Time { get; set; }

        [Column("event_id", TypeName= "integer")]
        public int? EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}
