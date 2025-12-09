namespace EatForm.Entities;

public class Meal
{
    public int Id { get; set; }
    public string? Name { get; set; } = null!;
    public TimeSpan? Time { get; set; }
    public double TotalCalories { get; set; }
    
    public int MealPlanId { get; set; }
    public MealPlan MealPlan { get; set; } = null!;
    
    public ICollection<MealProduct>? MealProducts { get; set; }
}