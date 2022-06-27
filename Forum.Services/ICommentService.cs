using Forum.Domain.DbObjects;

namespace Forum.Services;

public interface ICommentService
{
    Comment GetById(Guid commentId);
    List<Comment> GetByPostId(Guid postId);
    Comment PublishComment(string content, Guid author, Guid post);
}