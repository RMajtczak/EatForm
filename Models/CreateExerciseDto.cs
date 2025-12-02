namespace EatForm.Models;

public class CreateExerciseDto
{
    public string Name { get; set; } = null!;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public decimal? Weight { get; set; }
    public int? RestTime { get; set; }
    public int WorkoutId { get; set; }
    
}