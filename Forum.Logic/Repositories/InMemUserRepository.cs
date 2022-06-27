using Forum.Domain.DbObjects;
using Forum.Services;

namespace Forum.Logic.Repositories;

public class InMemUserRepository : IUserRepository
{
    private List<User> _users = new();

    public User GetById(Guid id)
        => _users.FirstOrDefault(a => a.Id == id)!;

    public User GetByEmail(string email)
        => _users.FirstOrDefault(a => a.Email.Equals(email))!;

    public void Add(User user)
        => _users.Add(user);

    public void Update(User user)
    {
        Remove(user.Id);
        Add(user);
    }

    public void Remove(Guid id)
    {
        _users.Remove(GetById(id));
    }

    public IEnumerable<User> GetAll()
        => new List<User>(_users);
}