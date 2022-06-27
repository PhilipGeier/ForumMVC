using Forum.Domain.DbObjects;
using Forum.Services;

namespace Forum.Db.Sql.Repositories;

public class SqlCommentRepository : ICommentRepository
{
    private const string CollectionName = "comments";
    private readonly List<Comment> _collection;

    public SqlCommentRepository(SqlCollectionGetter<Comment> collectionGetter)
    {
        _collection = collectionGetter.GetCollection(CollectionName).ToList();
    }

    public Comment GetById(Guid id)
    {
        return _collection
            .Find(a => a.Id == id)!;
    }

    public void Add(Comment comment)
    {
        _collection.Add(comment);
    }

    public void Update(Comment comment)
    {
        var oldComment = _collection.Find(a => a.Id == comment.Id);

        if (oldComment != null)
        {
            _collection.Remove(oldComment);
            _collection.Add(oldComment);
        }
    }

    public void Remove(Guid commentId)
    {
        var commentToRemove= _collection.Find(a => a.Id == commentId);
        
        if (commentToRemove != null)
            _collection.Remove(commentToRemove);
    }

    public IEnumerable<Comment> GetByPostId(Guid postId)
    {
        return _collection.FindAll(a => a.Post == postId);
    }
}