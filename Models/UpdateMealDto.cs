namespace EatForm.Models;

public class UpdateMealDto
{
    public string? Name { get; set; }
    public TimeSpan? Time { get; set; }
    public List<UpdateMealProductDto>? Products { get; set; }
}