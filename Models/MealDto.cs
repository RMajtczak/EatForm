namespace EatForm.Models;

public class MealDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public TimeSpan Time { get; set; }
    public int TotalCalories { get; set; }
    public int MealPlanId { get; set; }
    public List<MealProductDto> Products { get; set; } = new();
    
}