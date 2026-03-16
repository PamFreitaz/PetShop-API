using System.Data;

namespace pet.Domain.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
}