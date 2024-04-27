using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ZooManager.Models;

namespace ZooManager.Views
{
    public partial class EmployeeEditor : Window, INotifyPropertyChanged
    {

        private Employee _employee = Employee.Create();

        public Employee Employee
        {

            get
            {
                return _employee;
            }

            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged();
                }
            }

        }

        public EmployeeEditor()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
