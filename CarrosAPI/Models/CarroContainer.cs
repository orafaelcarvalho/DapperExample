namespace CarrosAPI.Models
{
    public class CarroContainer
    {
        public int Contador { get; set; }
        public IEnumerable<Carro> Carros { get; set; }
    }
}
