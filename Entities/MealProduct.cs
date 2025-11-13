namespace EatForm.Entities;

public class MealProduct
{ 
    public int Id { get; set; }
    public decimal Quantity { get; set; }
    
    public int MealId { get; set; }
    public Meal Meal { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}