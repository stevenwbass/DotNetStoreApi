using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace StoreData.Repositories.Db;

public class DbConnectionFactory : IDbConnectionFactory
{
    private static string? _connectionString = "";
    public DbConnectionFactory(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("store");
    }

    public IDbConnection New() {
        return new MySqlConnection(_connectionString);
    }
}

public interface IDbConnectionFactory {
    public IDbConnection New();
}