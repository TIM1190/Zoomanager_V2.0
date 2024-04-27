using ZooManager.Api.Models;

namespace ZooManager.Api.Services.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ZooManagetDbContext _dbContext;

        public EmployeeRepository(ZooManagetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Employee item)
        {
            _dbContext.Employees.Add(item);
            _dbContext.SaveChanges();
            return item.Id;
        }

        public ICollection<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            return _dbContext.Employees.FirstOrDefault(item => item.Id == id);
        }

        public bool Remove(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Employee item)
        {
            if (item == null)
                return false;
            var employee = GetById(item.Id);
            if (employee != null)
            {
                employee.ContactInfo = item.ContactInfo;
                employee.Name = item.Name;
                employee.Position = item.Position;
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }
    }
}
