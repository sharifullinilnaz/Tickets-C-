using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Data.Models
{
    [Table("events")]
    public class Event
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Column("name", TypeName = "varchar(150)")]
        public string Name { get; set; }

        /// <summary>
        /// Время
        /// </summary>
        [Column("time", TypeName = "time")]
        public double Time { get; set; }

        /// <summary>
        /// Стадион
        /// </summary>
        [Column("stadium", TypeName = "varchar(150)")]
        public string Description { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
