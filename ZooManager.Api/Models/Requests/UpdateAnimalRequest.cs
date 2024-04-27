namespace ZooManager.Api.Models.Requests
{
    public class UpdateAnimalRequest
    {

        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; set; }

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
