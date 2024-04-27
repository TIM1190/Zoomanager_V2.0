using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : Entity
    {
        private string _name;
        private string _position;
        private string _contactInfo;

        /// <summary>
        /// Фабричный метод для создания нового животного
        /// </summary>
        /// <returns></returns>
        public static Employee Create()
        {
            return new Employee(Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Position
        {
            get
            {
                return _position;
            }

            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Контактная информация
        /// </summary>
        public string ContactInfo
        {
            get
            {
                return _contactInfo;
            }

            set
            {
                if (_contactInfo != value)
                {
                    _contactInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public Employee() { }

        public Employee(string id)
        {
            Id = id;
        }

        public Employee(string name, string position, string contactInfo)
        {
            Name = name;
            Position = position;
            ContactInfo = contactInfo;
        }
    }
}
