using MySql.Data.MySqlClient;
using System.Data;

namespace CarrosAPI.Data
{
    public class DbSession : IDbSession
    {
        public IDbConnection Connection { get; set; }

        public DbSession(string connectionString)
        {
            try
            {
                Connection = new MySqlConnection(connectionString);

                Connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose() => Connection.Close();
    }
}
