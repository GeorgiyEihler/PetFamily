using Npgsql;
using PetFamily.Application.Abstraction.Persistense;
using System.Data;

namespace PetFamily.Infrastructure.SlqConnectionFactories;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
