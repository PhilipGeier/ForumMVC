using System.Reflection;
using Forum.Services;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Forum.Db.Sql;

public class SqlDbFactory<T> where T : new()
{
    private readonly IDatabaseService _databaseService;
    private static MySqlConnection _sqlConnection;

    public SqlDbFactory(IDatabaseService databaseService)
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
    
    
    public IEnumerable<T> GetCollection(string collectionName)
    {
        var query = $"SELECT * FROM {collectionName}";
        
        IEnumerable<T> ret = new List<T>();
        var command = new MySqlCommand(query, _sqlConnection);

        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            T t = new T();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Type type = t.GetType();
                PropertyInfo prop = type.GetProperty(reader.GetName(i));
                prop.SetValue(t, Convert.ChangeType(reader.GetValue(i), prop.PropertyType), null);
            }

            ret.Append(t);
        }

        return ret;
    }
    
}