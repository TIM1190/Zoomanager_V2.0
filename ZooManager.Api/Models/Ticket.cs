using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManager.Api.Models
{
    [Table("Tickets")]
    public class Ticket : Models.Entity.Entity
    {

        /// <summary>
        /// Уникальный НОМЕР билета (Guid)
        /// </summary>
        public string No { get; set; } = null!;

        /// <summary>
        /// Тип билета
        /// </summary>
        public string TicketType { get; set; } = null!;

        /// <summary>
        /// Стоимость билета
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Экскурсия
        /// </summary>
        public bool Excursion { get; set; }

        /// <summary>
        /// Кормление животных
        /// </summary>
        public bool FeedingTheAnimals { get; set; } 

        /// <summary>
        /// Фотосессия
        /// </summary>
        public bool Photoshoot { get; set; }

    }
}
