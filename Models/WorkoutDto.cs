namespace EatForm.Models;

public class WorkoutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Difficulty { get; set; }
    public decimal AvgRating { get; set; } = 0;
    public bool IsPublic { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    
}