using MySql.Data.MySqlClient;

namespace Forum.Db.Sql;

public interface ISqlDbFactory
{
    MySqlConnection GetConnection();
}