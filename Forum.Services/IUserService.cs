using Forum.Domain.DbObjects;

namespace Forum.Services;

public interface IUserService
{
    User GetById(Guid userId);
    User GetByEmail(string email);
    User Register(string username, string email, string password);
}