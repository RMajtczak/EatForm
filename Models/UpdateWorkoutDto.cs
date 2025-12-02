namespace EatForm.Models;

public class UpdateWorkoutDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Difficulty { get; set; }
    public bool? IsPublic { get; set; }
}