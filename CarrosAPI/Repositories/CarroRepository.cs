using CarrosAPI.Data;
using CarrosAPI.Models;
using Dapper;
using Org.BouncyCastle.Utilities.Collections;

namespace CarrosAPI.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly IDbSession _conn;
        public CarroRepository(IDbSession conn)
        {
            _conn = conn;
        }

        public async Task<int> DeleteCarro(int id)
        {
            using (var conn = _conn.Connection)
            {
                string command = "DELETE FROM CARROS WHERE ID = @ID";

                int result = await conn.ExecuteAsync(sql: command, param: new { id });

                return result;
            }
        }

        public async Task<Carro> GetCarroById(int id)
        {
            using (var conn = _conn.Connection)
            {
                string query = "SELECT * FROM CARROS WHERE ID = @ID";

                Carro carro = await conn.QueryFirstOrDefaultAsync<Carro>(sql: query, param: new {id});

                return carro;
            }
        }

        public async Task<IEnumerable<Carro>> GetCarros()
        {
            using (var conn = _conn.Connection)
            {
                string query = "SELECT * FROM CARROS";

                IEnumerable<Carro> result = (await conn.QueryAsync<Carro>(sql: query)).ToList();
                return result;
            }

        }

        public async Task<CarroContainer> GetContainer()
        {
            using (var conn = _conn.Connection)
            {
                string query = @"SELECT COUNT(*) FROM CARROS;
                                 SELECT * FROM CARROS";

                var reader = await conn.QueryMultipleAsync(sql: query);

                return new CarroContainer
                {
                    Contador = (await reader.ReadAsync<int>()).FirstOrDefault(),
                    Carros = (await reader.ReadAsync<Carro>()).ToList()
                };
            }
        }

        public async Task<int> PostCarro(Carro carro)
        {
            using (var conn = _conn.Connection)
            {
                string command = @"INSERT INTO CARROS (DESCRICAO, MARCA, VALOR)
                                   VALUES(@DESCRICAO, @MARCA, @VALOR)";

                int result = await conn.ExecuteAsync(sql: command, param: carro);

                return result;
            }
        }

        public async Task<int> UpdateCarro(Carro carro)
        {
            using (var conn = _conn.Connection)
            {
                string command = @"UPDATE CARROS SET DESCRICAO = @DESCRICAO, MARCA = @MARCA, VALOR = @VALOR WHERE ID = @ID";

                int result = await conn.ExecuteAsync(sql: command, param: carro);

                return result;
            }
        }
    }
}
