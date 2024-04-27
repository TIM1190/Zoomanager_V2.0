namespace ZooManager.Api.Models.Requests
{
    public class UpdateEmployeeRequest
    {

        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; set; }

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
