using System.Diagnostics;
using EatForm.Entities;

namespace EatForm;

public class DbSeeder
{
    private readonly EatFormDbContext _dbContext;

    public DbSeeder(EatFormDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (!_dbContext.Products.Any())
        {
            var products = GetProducts().ToList();
            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }

        var product1 = _dbContext.Products.First(p => p.Name == "Kurczak (pierś)");
        var product2 = _dbContext.Products.First(p => p.Name == "Ryż biały");
        var product3 = _dbContext.Products.First(p => p.Name == "Owsianka");
        var product4 = _dbContext.Products.First(p => p.Name == "Banany");
        var product5 = _dbContext.Products.First(p => p.Name == "Jajka");
        
        var meal1 = _dbContext.Meals.First(m => m.Name == "Kurczak z ryżem");
        var meal2 = _dbContext.Meals.First(m => m.Name == "Owsianka z bananem");
        var meal3 = _dbContext.Meals.First(m => m.Name == "Jajecznica");

        // 8. Meal Products
        if (!_dbContext.MealProducts.Any())
        {
            var mealProducts = new List<MealProduct>
            {
                new MealProduct { MealId = meal1.Id, ProductId = product1.Id, Quantity = 150 },
                new MealProduct { MealId = meal1.Id, ProductId = product2.Id, Quantity = 100 },
                new MealProduct { MealId = meal2.Id, ProductId = product3.Id, Quantity = 80 },
                new MealProduct { MealId = meal2.Id, ProductId = product4.Id, Quantity = 120 },
                new MealProduct { MealId = meal3.Id, ProductId = product5.Id, Quantity = 3 }
            };
            _dbContext.MealProducts.AddRange(mealProducts);
            _dbContext.SaveChanges();
        }
    }
    private IEnumerable<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product { Name = "Kurczak (pierś)", Calories = 165, Protein = 31, Carbs = 0, Fat = 3, IsGlobal = true },
            new Product { Name = "Ryż biały", Calories = 360, Protein = 7, Carbs = 80, Fat = 1, IsGlobal = true },
            new Product { Name = "Owsianka", Calories = 370, Protein = 13, Carbs = 60, Fat = 7, IsGlobal = true },
            new Product { Name = "Banany", Calories = 89, Protein = 1, Carbs = 23, Fat = 0, IsGlobal = true },
            new Product { Name = "Jajka", Calories = 155, Protein = 13, Carbs = 1, Fat = 11, IsGlobal = true }
        };
    }
}
