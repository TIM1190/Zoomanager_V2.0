using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Models
{
    /// <summary>
    /// Животное
    /// </summary>
    public class Animal : Entity
    {

        private string _species;
        private int _age;
        private double _weight;
        private bool _isPredator;
        private string _habitat;
        private string _enclosureSize;

        public Animal()
        {
        }

        private Animal(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Фабричный метод для создания нового животного
        /// </summary>
        /// <returns></returns>
        public static Animal Create()
        {
            return new Animal(Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Возраст животного
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Является ли хищником
        /// </summary>
        public bool IsPredator
        {
            get
            {
                return _isPredator;
            }

            set
            {
                if (_isPredator != value)
                {
                    _isPredator = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Среда обитания
        /// </summary>
        public string Habitat
        {
            get
            {
                return _habitat;
            }

            set
            {
                if (_habitat != value)
                {
                    _habitat = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Размер вальера
        /// </summary>
        public string EnclosureSize
        {
            get
            {
                return _enclosureSize;
            }

            set
            {
                if (_enclosureSize != value)
                {
                    _enclosureSize = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Вид животного
        /// </summary>
        public string Species
        {
            get
            {
                return _species;
            }

            set
            {
                if (_species != value)
                {
                    _species = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
