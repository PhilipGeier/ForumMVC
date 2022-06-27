using Forum.Domain.DbObjects;
using Forum.Domain.Enums;
using Forum.Logic;
using Forum.Logic.Repositories;
using Forum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forum.Test;

[TestClass]
public class BasicPostTest
{
    [TestMethod]
    public void TestGetById()
    {
        var post = new Post()
        {
            Id = Guid.NewGuid(),
            Title = "testTitle",
            Content = "testContent",
            Tag = PostTag.News,
            Author = Guid.NewGuid()
        };
        
        _postRepository.Add(post);

        var post2 = _postService.GetById(post.Id);
        
        Assert.AreEqual(post.Id, post2.Id);
    }
    
    [TestInitialize]
    public void TestInit()
    {
        _postRepository = new InMemPostRepository();
        _postService = new BasicPostService(_postRepository);
    }

    private IPostService _postService;
    private IPostRepository _postRepository;
}