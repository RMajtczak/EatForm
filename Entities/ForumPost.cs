namespace EatForm.Entities;

public class ForumPost
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public bool IsTrainerAnswer { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public int ThreadId { get; set; }
    public ForumThread Thread { get; set; } = null!;

    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;
}