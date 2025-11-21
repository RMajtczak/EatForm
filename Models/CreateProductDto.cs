namespace EatForm.Models;

public class CreateProductDto
{
    public string Name { get; set; } = null!;
    public int Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public bool IsGlobal { get; set; } = true;
}