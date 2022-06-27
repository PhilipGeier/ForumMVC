using Forum.Domain.DbObjects;
using Forum.Domain.Enums;

namespace Forum.Services;

public interface IPostService
{
    Post GetById(Guid postId);
    List<Post> GetBySearch(string search);
    Post Publish(string title, string content, Guid author, PostTag tag);
}