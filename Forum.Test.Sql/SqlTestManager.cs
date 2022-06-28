using Forum.Db.Sql;
using Forum.Domain.DbObjects;
using Forum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MySql.Data.MySqlClient;

namespace Forum.Test.Sql;

[TestClass]
public class SqlTestManager
{
    public static ISqlDbFactory SqlDbFactory;
    public static SqlCollectionGetter<User> SqlCollectionGetter;
    private static DevDatabaseService _devDatabaseService = new();
    private static string databaseName = "test_forum";

    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        string connectionString = _devDatabaseService.GetConnectionString();

        var connection = new MySqlConnection(connectionString);

        var mock = new Mock<IDatabaseService>();
        mock.Setup(a => a.GetConnectionString()).Returns(connectionString);


        SqlCollectionGetter = new SqlCollectionGetter<User>();
        SqlDbFactory = new ImplSqlDbFactory(mock.Object);
    }
}