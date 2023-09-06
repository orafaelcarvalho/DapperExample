using CarrosAPI.Models;
using CarrosAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private ICarroRepository _carroRepository;
        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Carro>> Get()
        {
            return _carroRepository.GetCarros();
        }
                
        [HttpGet("{id}")]
        public Task<Carro> Get(int id)
        {
            return _carroRepository.GetCarroById(id);
        }

        [HttpGet ("Container/")]
        public Task<CarroContainer> GetContainer()
        {
            return _carroRepository.GetContainer();
        }
                
        [HttpPost]
        public Task<int> Post([FromBody] Carro carro)
        {
            return _carroRepository.PostCarro(carro);
        }

        [HttpPut]
        public Task<int> Put([FromBody] Carro carro)
        {
            return _carroRepository.UpdateCarro(carro);
        }

        [HttpDelete("{id}")]
        public Task<int> Delete(int id)
        {
            return _carroRepository.DeleteCarro(id);
        }
    }
}
