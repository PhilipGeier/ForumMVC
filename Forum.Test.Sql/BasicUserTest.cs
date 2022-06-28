using Forum.Db.Sql;
using Forum.Db.Sql.Repositories;
using Forum.Domain.DbObjects;
using Forum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forum.Test.Sql;

[TestClass]
public class BasicUserTest
{
    [TestMethod]
    public void TestAddUser()
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Username = "test_user",
            Email = "test_email",
            Password = "test_password",
            IsAdmin = false
        };
        
        _userRepository.Add(user);

        var user2 = _userRepository.GetById(user.Id);
        
        Assert.AreEqual(user, user2);
    }

    [TestInitialize]
    public void TestInit()
    {
        _userRepository = new SqlUserRepository(SqlTestManager.SqlCollectionGetter);
    }

    private IUserRepository _userRepository;
    private SqlCollectionGetter<User> _sqlCollectionGetter;
}