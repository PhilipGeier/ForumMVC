using Forum.Domain.DbObjects;
using Forum.Logic;
using Forum.Logic.Repositories;
using Forum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forum.Test;

[TestClass]
public class BasicUserTest
{
    [TestMethod]
    public void TestGetById()
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Username = "test",
            Email = "test@mail.com",
            Password = "testpw",
            IsAdmin = false
        };
        _userRepository.Add(user);

        var user2 = _userService.GetById(user.Id);
        
        Assert.AreEqual(user.Id, user2.Id);
    }

    [TestMethod]
    public void TestGetByEmail()
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Username = "test",
            Email = "test@mail.com",
            Password = "testpw",
            IsAdmin = false
        };
        _userRepository.Add(user);

        var user2 = _userService.GetByEmail(user.Email);
        
        Assert.AreEqual(user.Email, user2.Email);
    }

    [TestMethod]
    public void TestRegister()
    {
        _userService.Register("testUsername", "test@mail.com", "testPassword");

        var user = _userService.GetByEmail("test@mail.com");
        
        Assert.IsNotNull(user);
        Assert.AreEqual("test@mail.com", user.Email);
    }

    [TestInitialize]
    public void TestInit()
    {
        _userRepository = new InMemUserRepository();
        _userService = new BasicUserService(_userRepository);
    }
    
    private IUserService _userService;
    private IUserRepository _userRepository;
}