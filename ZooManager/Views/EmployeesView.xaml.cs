using System;
using System.Collections.Generic;
using System.Linq;
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
using ZooManager.Services.Imp;
using ZooManager.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZooManager.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : UserControl, INotifyPropertyChanged
    {
        private Employee _selectedEmployee;
        private IEmployeesRepository _employeesRepository;
        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public EmployeesView()
        {
            InitializeComponent();
            Initialize();
            DataContext = this;
        }

        public void Initialize()
        {
            _employeesRepository = new EmployeesServiceRepository();
        }

        private void UpdateEmployees_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employees = _employeesRepository.GetAll();
            }
            catch(Exception)
            {
                MessageBox.Show("Невозможно загрузить данные.\nПовторите попытку позже.", "ZooManager", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddEmployee_Click(object sender, object e)
        {
            try
            {
                var employeeEditor = new EmployeeEditor();
                employeeEditor.Title = "Сотрудник [добавление]";
                if (employeeEditor.ShowDialog() == true)
                {
                    _employeesRepository.Add(employeeEditor.Employee);
                    Employees = _employeesRepository.GetAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно добавить сотрудника.\nПовторите попытку позже.", "ZooManager",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EditEmployee_Click(object sender, object e)
        {
            if (SelectedEmployee != null)
            {
                try
                {
                    var employeeEditor = new EmployeeEditor();
                    employeeEditor.Employee = (Employee)SelectedEmployee.Clone();
                    employeeEditor.Title = "Сотрудник [редактирование]";
                    if (employeeEditor.ShowDialog() == true)
                    {
                        _employeesRepository.Update(employeeEditor.Employee);
                        SelectedEmployee.Name = employeeEditor.Employee.Name;
                        SelectedEmployee.Position = employeeEditor.Employee.Position;
                        SelectedEmployee.ContactInfo = employeeEditor.Employee.ContactInfo;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно обновить данные по сотруднику.\nПовторите попытку позже.", "ZooManager",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void DeleteEmployee_Click(object sender, object e)
        {
            if (SelectedEmployee != null && MessageBox.Show("Вы действительно желаете удалить запись?", "ZooManager",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _employeesRepository.Remove(SelectedEmployee);
                    Employees = _employeesRepository.GetAll();
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно удалить сотрудника.\nПовторите попытку позже.", "ZooManager",
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
