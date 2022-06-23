namespace Forum.Domain.DbObjects;

public record User
{
    public Guid Id { get; init; }
    public string Username { get; init; }
    public string Email { get; set; }
    public string Password { get; init; }
    public bool IsAdmin { get; init; }
}