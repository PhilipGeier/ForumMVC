namespace Forum.Domain.DbObjects;

public record Comment
{
    public Guid Id { get; init; }
    public string Content { get; init; }
    public DateTime PostDate { get; init; }
    public Guid Author { get; init; }
    public Guid Post { get; init; }
}