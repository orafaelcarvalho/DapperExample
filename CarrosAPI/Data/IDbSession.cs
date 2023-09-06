using System.Data;

namespace CarrosAPI.Data
{
    public interface IDbSession : IDisposable
    {
        public IDbConnection Connection { get; set; }
    }
}
