using Forum.Domain.DbObjects;
using Forum.Domain.Enums;
using Forum.Services;

namespace Forum.Logic;

public class BasicPostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public BasicPostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public Post GetById(Guid postId) => _postRepository.GetById(postId);

    public List<Post> GetBySearch(string search)
        => _postRepository.GetAll().Where(a => a.Title.Contains(search)).ToList();


    public Post Publish(string title, string content, Guid author, PostTag tag)
    {
        var id = Guid.NewGuid();
        
        _postRepository.Add(new Post()
        {
            Id = id,
            Title = title,
            Author = author,
            Tag = tag,
            PostDate = DateTime.Now
        });

        return _postRepository.GetById(id);
    }
}