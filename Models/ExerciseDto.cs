namespace EatForm.Models;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public decimal? Weight { get; set; }
    public int? RestTime { get; set; }
}