using Forum.Domain.Enums;

namespace Forum.Domain.DbObjects;

public record Post
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime PostDate { get; init; }
    public Guid Author { get; init; }
    public PostTag Tag { get; init; }
}