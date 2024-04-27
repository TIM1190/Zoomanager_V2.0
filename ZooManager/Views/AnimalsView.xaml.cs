using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZooManager.Models;
using ZooManager.Services;
using ZooManager.Services.Imp;

namespace ZooManager.Views
{
    public partial class AnimalsView : UserControl, INotifyPropertyChanged
    {

        private Animal _selectedAnimal;
        private IAnimalsRepository _animalsRepository;
        private ObservableCollection<Animal> _animals;

        public ObservableCollection<Animal> Animals
        {
            get { return _animals; }
            set
            {
                _animals = value;
                OnPropertyChanged();
            }
        }

        public Animal SelectedAnimal
        {
            get { return _selectedAnimal; }
            set
            {
                _selectedAnimal = value;
                OnPropertyChanged();
            }
        }

        public AnimalsView()
        {
            InitializeComponent();
            Initialize();
            DataContext = this;
        }

        public void Initialize()
        {
            _animalsRepository = new AnimalsServiceRepository();
        }

        private void UpdateAnimals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animals = _animalsRepository.GetAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно загрузить данные.\nПовторите попытку позже.", "ZooManager",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var animalEditor = new AnimalEditor();
                animalEditor.Title = "Животные [добавление]";
                if (animalEditor.ShowDialog() == true)
                {
                    _animalsRepository.Add(animalEditor.Animal);
                    Animals = _animalsRepository.GetAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно добавить животное.\nПовторите попытку позже.", "ZooManager",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAnimal != null)
            {
                try
                {
                    var animalEditor = new AnimalEditor();
                    animalEditor.Animal = (Animal)SelectedAnimal.Clone();
                    animalEditor.Title = "Животные [редактирование]";
                    if (animalEditor.ShowDialog() == true)
                    {
                        _animalsRepository.Update(animalEditor.Animal);
                        SelectedAnimal.Species = animalEditor.Animal.Species;
                        SelectedAnimal.Habitat = animalEditor.Animal.Habitat;
                        SelectedAnimal.Weight = animalEditor.Animal.Weight;
                        SelectedAnimal.IsPredator = animalEditor.Animal.IsPredator;
                        SelectedAnimal.EnclosureSize = animalEditor.Animal.EnclosureSize;
                        Animals = _animalsRepository.GetAll();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно обновить информаци по животному.\nПовторите попытку позже.", "ZooManager",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAnimal != null && MessageBox.Show("Вы действительно желаете удалить запись?", "ZooManager",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _animalsRepository.Remove(SelectedAnimal);
                    Animals = _animalsRepository.GetAll();
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно удалить животное.\nПовторите попытку позже.", "ZooManager",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    
    }
}
