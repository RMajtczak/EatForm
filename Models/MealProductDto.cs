namespace EatForm.Models;

public class MealProductDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public double Quantity { get; set; }
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }
}