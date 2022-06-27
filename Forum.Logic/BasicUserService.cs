using System.Net;
using Forum.Domain.DbObjects;
using Forum.Domain.Enums;
using Forum.Domain.Exceptions;
using Forum.Services;

namespace Forum.Logic;

public class BasicUserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public BasicUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetById(Guid userId) => _userRepository.GetById(userId);
    
    public User GetByEmail(string email) => _userRepository.GetByEmail(email);

    public User Register(string username, string email, string password)
    {
        if (GetByEmail(email) != null)
            throw new UserException();
        
        _userRepository.Add(new User()
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = email,
            Password = password,
            IsAdmin = false
        });
        

        return _userRepository.GetByEmail(email);
    }
}