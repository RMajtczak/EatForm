namespace EatForm.Entities;

public class ForumThread
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // FK
    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;

    // Nawigacja
    public ICollection<ForumPost>? Posts { get; set; }
}