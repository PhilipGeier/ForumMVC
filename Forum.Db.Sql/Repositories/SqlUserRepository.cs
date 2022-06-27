using Forum.Domain.DbObjects;
using Forum.Services;

namespace Forum.Db.Sql.Repositories;

public class SqlUserRepository : IUserRepository
{
    private const string CollectionName = "users";
    private readonly List<User> _collection;
    
    public SqlUserRepository(SqlCollectionGetter<User> collectionGetter)
    {
        _collection = collectionGetter.GetCollection(CollectionName).ToList();
    }
    
    public User GetById(Guid id)
    {
        return _collection
            .Find(a => a.Id == id)!;
    }
    
    public User GetByEmail(string email)
    {
        return _collection
            .FindAll(a => a.Email.Equals(email))
            .FirstOrDefault()!;
    }

    public void Add(User user)
    {
        _collection.Add(user);
    }

    public void Update(User user)
    {
        var oldUser = _collection.Find(a => a.Id == user.Id);

        if (oldUser != null && oldUser.Id == user.Id)
        {   
            _collection.Remove(oldUser);
            _collection.Add(user);
        }
    }

    public void Remove(Guid id)
    {
        var userToRemove= _collection.Find(a => a.Id == id);
        
        if (userToRemove != null)
            _collection.Remove(userToRemove);
        
    }

    public IEnumerable<User> GetAll()
    {
        return _collection;
    }
}