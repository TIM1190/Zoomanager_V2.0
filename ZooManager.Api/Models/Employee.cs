using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ZooManager.Api.Models
{
    [Table("Employees")]
    public class Employee : Models.Entity.Entity
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Position { get; set; } = null!;

        /// <summary>
        /// Контактная информация
        /// </summary>
        public string ContactInfo { get; set; } = null!;
    }
}
