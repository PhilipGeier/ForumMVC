using Forum.Domain;
using Forum.Domain.DbObjects;

namespace Forum.Services;

public interface IUserRepository
{
    User GetById(Guid id);
    User GetByEmail(string email);
    void Add(User user);
    void Update(User user);
    void Remove(Guid id);
    IEnumerable<User> GetAll();
}