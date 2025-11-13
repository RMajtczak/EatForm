namespace EatForm.Entities;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Difficulty { get; set; }
    public decimal AvgRating { get; set; } = 0;
    public bool IsPublic { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    public ICollection<Exercise>? Exercises { get; set; }
    public ICollection<WorkoutRating>? Ratings { get; set; }
}