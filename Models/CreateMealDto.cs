namespace EatForm.Models;

public class CreateMealDto
{
    public string Name { get; set; } = null!;
    public TimeSpan Time { get; set; }
    public List<CreateMealProductDto> Products { get; set; } = new();
}