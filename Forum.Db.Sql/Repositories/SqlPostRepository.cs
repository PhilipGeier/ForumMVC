using Forum.Domain.DbObjects;
using Forum.Services;

namespace Forum.Db.Sql.Repositories;

public class SqlPostRepository : IPostRepository
{
    private const string CollectionName = "posts";
    private readonly List<Post> _collection;

    public SqlPostRepository(SqlDbFactory<Post> factory)
    {
        _collection = factory.GetCollection(CollectionName).ToList();
    }
    
    public Post GetById(Guid id)
    {
        return _collection
            .Find(a => a.Id == id)!;
    }

    public void Add(Post post)
    {
        _collection.Add(post);
    }

    public void Update(Post post)
    {
        var oldPost = _collection.Find(a => a.Id == post.Id);

        if (oldPost != null)
        {
            _collection.Remove(oldPost);
            _collection.Add(post);
        }
    }

    public void Remove(Guid id)
    {
        var postToRemove = _collection.Find(a => a.Id == id);

        if (postToRemove != null)
            _collection.Remove(postToRemove);
    }

    public IEnumerable<Post> GetAll()
    {
        return _collection;
    }
}