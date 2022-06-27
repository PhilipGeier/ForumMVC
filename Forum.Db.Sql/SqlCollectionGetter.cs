using System.Reflection;
using MySql.Data.MySqlClient;

namespace Forum.Db.Sql;

public class SqlCollectionGetter<T>  where T : new()
{
    private MySqlConnection _sqlConnection = ImplSqlDbFactory._sqlConnection;
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
