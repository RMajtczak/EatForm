namespace EatForm.Models;

public class UpdateExerciseDto
{
    public string? Name { get; set; }
    public int? Sets { get; set; }
    public int? Reps { get; set; }
    public decimal? Weight { get; set; }
    public int? RestTime { get; set; }
    public int? WorkoutId { get; set; }
}