using System.Collections.ObjectModel;
using ZooManager.Models;

namespace ZooManager.Services.Imp
{
    public class EmployeesServiceRepository : IEmployeesRepository
    {
        private ZooManager.Data.ZooManagerClient _zooManagerClient =
            new Data.ZooManagerClient("http://localhost:5290", new System.Net.Http.HttpClient());
        
        public void Add(Employee item)
        {
            var id = _zooManagerClient.EmployeeCreateAsync(new Data.CreateEmployeeRequest
            {
                ContactInfo = item.ContactInfo,
                Name = item.Name,
                Position = item.Position,
            }).Result;
            item.Id = id.ToString();
        }

        public ObservableCollection<Employee> GetAll()
        {
            return new ObservableCollection<Employee>(
                _zooManagerClient.EmployeeGetAllAsync().Result.Select
                (item => new Employee
                {
                    Id = item.Id.ToString(),
                    Name = item.Name,
                    ContactInfo = item.ContactInfo,
                    Position = item.Position,
                }));
        }

        public void Remove(Employee item)
        {
            var res = _zooManagerClient.EmployeeDeleteAsync(int.Parse(item.Id)).Result;
        }

        public void Update(Employee item)
        {
            var res = _zooManagerClient.EmployeeUpdateAsync(new Data.UpdateEmployeeRequest
            {
                Id = int.Parse(item.Id),
                ContactInfo = item.ContactInfo,
                Name = item.Name,
                Position = item.Position,
            }).Result;
        }
    }
}
