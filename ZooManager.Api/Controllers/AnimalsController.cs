using Microsoft.AspNetCore.Mvc;
using ZooManager.Api.Models;
using ZooManager.Api.Models.Requests;
using ZooManager.Api.Services;

namespace ZooManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpPost("create", Name = "AnimalCreate")]
        public ActionResult<int> Create([FromBody] CreateAnimalRequest request)
        {
            var animal = new Animal()
            {
                Species = request.Species,
                Weight = request.Weight,
                Age = request.Age,
                IsPredator = request.IsPredator,
                Habitat = request.Habitat,
                EnclosureSize = request.EnclosureSize
            };
            return Ok(_animalRepository.Add(animal));
        }

        [HttpPut("update", Name = "AnimalUpdate")]
        public ActionResult<bool> Update([FromBody] UpdateAnimalRequest request)
        {
            var animal = new Animal()
            {
                Id = request.Id,
                Species = request.Species,
                Weight = request.Weight,
                Age = request.Age,
                IsPredator = request.IsPredator,
                Habitat = request.Habitat,
                EnclosureSize = request.EnclosureSize
            };
            return Ok(_animalRepository.Update(animal));
        }

        [HttpDelete("delete", Name = "AnimalDelete")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_animalRepository.Remove(id));
        }

        [HttpGet("get-all", Name = "AnimalGetAll")]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_animalRepository.GetAll());
        }

        [HttpGet("get-by-id", Name = "AnimalGetById")]
        public ActionResult<Animal?> GetById(int id)
        {
            return Ok(_animalRepository.GetById(id));
        }
    }
}
