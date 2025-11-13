namespace EatForm.Entities;

public class WorkoutRating
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
}