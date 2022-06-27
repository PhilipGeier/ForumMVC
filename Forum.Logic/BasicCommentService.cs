using Forum.Domain.DbObjects;
using Forum.Services;

namespace Forum.Logic;

public class BasicCommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public BasicCommentService(ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    public Comment GetById(Guid commentId)
        => _commentRepository.GetById(commentId);

    public List<Comment> GetByPostId(Guid postId)
        => _commentRepository.GetByPostId(postId).ToList();

    public Comment PublishComment(string content, Guid author, Guid post)
    {
        var id = Guid.NewGuid();

        if (_postRepository.GetById(post) == null)
            throw new ArgumentException("Post does not exist");
        
        _commentRepository.Add(new Comment()
        {
            
        });

        return null;
    }
}