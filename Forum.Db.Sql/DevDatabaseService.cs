using Forum.Services;

namespace Forum.Db.Sql;

public class DevDatabaseService : IDatabaseService
{
    public string GetConnectionString() => "server=localhost;uid=root;pwd=;database=forum;port=3306";
}