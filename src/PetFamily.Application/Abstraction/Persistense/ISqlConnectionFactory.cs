using System.Data;

namespace PetFamily.Application.Abstraction.Persistense;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
