using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManager.Api.Models
{
    [Table("Animals")]
    public class Animal : Models.Entity.Entity
    {

        /// <summary>
        /// Вид животного
        /// </summary>
        public string Species { get; set; } = null!;

        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Является ли хищником
        /// </summary>
        public bool IsPredator { get; set; }

        /// <summary>
        /// Среда обитания
        /// </summary>
        public string? Habitat { get; set; }

        /// <summary>
        /// Размер вальера
        /// </summary>
        public string? EnclosureSize { get; set; }

    }
}
