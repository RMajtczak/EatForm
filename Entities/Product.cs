namespace EatForm.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Carbs { get; set; }
    public decimal Fat { get; set; }
    public string? Category { get; set; }
    public bool IsGlobal { get; set; } = false;
    
    public int? CreatorId { get; set; }
    public User? Creator { get; set; }

    public ICollection<MealProduct>? MealProducts { get; set; }
}