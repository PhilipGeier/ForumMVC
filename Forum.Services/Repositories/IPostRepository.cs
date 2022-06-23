using Forum.Domain.DbObjects;

namespace Forum.Services;

public interface IPostRepository
{
    Post GetById(Guid id);
    void Add(Post post);
    void Update(Post post);
    void Remove(Guid id);
    IEnumerable<Post> GetAll();
}