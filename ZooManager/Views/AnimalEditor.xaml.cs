using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ZooManager.Models;

namespace ZooManager.Views
{
    public partial class AnimalEditor : Window, INotifyPropertyChanged
    {
        
        private Animal _animal = Animal.Create();

        public Animal Animal
        {

            get
            {
                return _animal;
            }

            set
            {
                if (_animal != value)
                {
                    _animal = value;
                    OnPropertyChanged();
                }
            }

        }

        public AnimalEditor()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
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
