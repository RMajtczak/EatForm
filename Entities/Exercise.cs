namespace EatForm.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public decimal? Weight { get; set; }
    public int? RestTime { get; set; }
    
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
}