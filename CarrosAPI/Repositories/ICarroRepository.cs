using CarrosAPI.Models;

namespace CarrosAPI.Repositories
{
    public interface ICarroRepository
    {
        Task<int> PostCarro(Carro carro);
        Task<Carro> GetCarroById(int id);
        Task<IEnumerable<Carro>> GetCarros();
        Task<int> DeleteCarro(int id);
        Task<int> UpdateCarro(Carro carro);
        Task<CarroContainer> GetContainer();
    }
}
