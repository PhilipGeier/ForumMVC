using Forum.Domain.DbObjects;
using Forum.Services;

namespace Forum.Logic.Repositories;

public class InMemCommentRepository : ICommentRepository
{
    private List<Comment> _comments = new();

    public Comment GetById(Guid id)
        => _comments.FirstOrDefault(a => a.Id == id)!;

    public void Add(Comment comment)
        => _comments.Add(comment);

    public void Update(Comment comment)
    {
        Remove(comment.Id);
        Add(comment);
    }

    public void Remove(Guid commentId)
        => _comments.Remove(GetById(commentId));

    public IEnumerable<Comment> GetByPostId(Guid postId)
        => _comments.FindAll(a => a.Post == postId);
}