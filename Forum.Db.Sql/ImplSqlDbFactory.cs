using System.Reflection;
using Forum.Services;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Forum.Db.Sql;

public class ImplSqlDbFactory : ISqlDbFactory
{
    private readonly IDatabaseService _databaseService;
    internal static MySqlConnection _sqlConnection;

    public ImplSqlDbFactory(IDatabaseService databaseService)
    {
        _databaseService = databaseService;

        if (_sqlConnection == null)
        {
            var connectionString = _databaseService.GetConnectionString();
            _sqlConnection = new MySqlConnection(connectionString);

        }
    }

    public MySqlConnection GetConnection()
        => _sqlConnection;
    
}


