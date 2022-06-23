using Forum.Db.Sql;
using Forum.Logic;
using Forum.Services;
using Forum.Domain;
using Forum.Domain.DbObjects;
using Forum.Logic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forum.Console;


public class Program
{
    public static void Main(string[] args)
    {
        IUserRepository _userRepository = new InMemUserRepository();
        IUserService _userService = new BasicUserService(_userRepository);
    
        
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
}
