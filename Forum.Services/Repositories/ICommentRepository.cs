using Forum.Domain.DbObjects;

namespace Forum.Services;

public interface ICommentRepository
{
    Comment GetById(Guid id);
    void Add(Comment comment);
    void Update(Comment comment);
    void Remove(Guid commentId);
    IEnumerable<Comment> GetByPostId(Guid postId);
}