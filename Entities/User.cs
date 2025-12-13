namespace EatForm.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public string? ActivityLevel { get; set; }
    public string? Goal { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<MealPlan>? MealPlans { get; set; }
    public ICollection<Workout>? Workouts { get; set; }
    public ICollection<WorkoutRating>? WorkoutRatings { get; set; }
    public ICollection<ForumThread>? ForumThreads { get; set; }
    public ICollection<ForumPost>? ForumPosts { get; set; }
}