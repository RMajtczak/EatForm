namespace EatForm.Models;

public class UpdateProductDto
{
    public string? Name { get; set; }
    public int? Calories { get; set; }
    public double? Protein { get; set; }
    public double? Carbs { get; set; }
    public double? Fat { get; set; }
    public bool? IsGlobal { get; set; }
}