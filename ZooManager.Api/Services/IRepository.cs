using System.Collections.ObjectModel;

namespace ZooManager.Api.Services
{
    public interface IRepository<T>
    {
        int Add(T item);
        bool Remove(int id);
        bool Update(T item);
        ICollection<T> GetAll();
        T? GetById(int id);
    }
}
