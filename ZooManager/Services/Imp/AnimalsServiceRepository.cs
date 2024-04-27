using System.Collections.ObjectModel;
using ZooManager.Models;

namespace ZooManager.Services.Imp
{
    public class AnimalsServiceRepository : IAnimalsRepository
    {
        private ZooManager.Data.ZooManagerClient _zooManagerClient =
            new Data.ZooManagerClient("http://localhost:5290", new System.Net.Http.HttpClient());

        public void Add(Animal item)
        {
            var id = _zooManagerClient.AnimalCreateAsync(new Data.CreateAnimalRequest
            {
                Age = item.Age,
                EnclosureSize = item.EnclosureSize,
                Habitat = item.Habitat,
                IsPredator = item.IsPredator,
                Species = item.Species,
                Weight = item.Weight
            }).Result;
            item.Id = id.ToString();
        }

        public ObservableCollection<Animal> GetAll()
        {
            return new ObservableCollection<Animal>(
                _zooManagerClient.AnimalGetAllAsync().Result.Select
                (item => new Animal
                {
                    Id = item.Id.ToString(),
                    Age = item.Age,
                    EnclosureSize = item.EnclosureSize,
                    Habitat = item.Habitat,
                    IsPredator = item.IsPredator,
                    Species = item.Species,
                    Weight = item.Weight
                }));
        }

        public void Remove(Animal item)
        {
            var res = _zooManagerClient.AnimalDeleteAsync(int.Parse(item.Id)).Result;
        }

        public void Update(Animal item)
        {
            var res = _zooManagerClient.AnimalUpdateAsync(new Data.UpdateAnimalRequest
            {
                Id = int.Parse(item.Id),
                Age = item.Age,
                EnclosureSize = item.EnclosureSize,
                Habitat = item.Habitat,
                IsPredator = item.IsPredator,
                Species = item.Species,
                Weight = item.Weight
            }).Result;
        }
    }
}
