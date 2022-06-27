using Forum.Domain.DbObjects;
using Forum.Services;

namespace Forum.Logic.Repositories;

public class InMemPostRepository : IPostRepository
{
    private List<Post> _posts = new();

    public Post GetById(Guid id)
        => _posts.FirstOrDefault(a => a.Id == id)!;

    public void Add(Post post)
        => _posts.Add(post);

    public void Update(Post post)
    {
        Remove(post.Id);
        Add(post);
    }

    public void Remove(Guid id)
        => _posts.Remove(GetById(id));

    public IEnumerable<Post> GetAll()
        => new List<Post>(_posts);
}