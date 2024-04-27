using ZooManager.Api.Models;

namespace ZooManager.Api.Services.Impl
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZooManagetDbContext _dbContext;

        public AnimalRepository(ZooManagetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Animal item)
        {
            _dbContext.Animals.Add(item);
            _dbContext.SaveChanges();
            return item.Id;
        }

        public ICollection<Animal> GetAll()
        {
            return _dbContext.Animals.ToList();
        }

        public Animal? GetById(int id)
        {
            return _dbContext.Animals.FirstOrDefault(item => item.Id == id);
        }

        public bool Remove(int id)
        {
            var animal = GetById(id);
            if (animal != null)
            {
                _dbContext.Animals.Remove(animal);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Animal item)
        {
            if (item == null)
                return false;
            var animal = GetById(item.Id);
            if (animal != null)
            {
                animal.Species = item.Species;
                animal.Weight = item.Weight;
                animal.Age = item.Age;
                animal.IsPredator = item.IsPredator;
                animal.Habitat = item.Habitat;
                animal.EnclosureSize = item.EnclosureSize;
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }
    }
}
