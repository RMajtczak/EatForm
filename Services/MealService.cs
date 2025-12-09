using AutoMapper;
using EatForm.Entities;
using EatForm.Models;
using Microsoft.EntityFrameworkCore;

namespace EatForm;

public interface IMealService
{
    IEnumerable<MealDto> GetAllMeals();
    MealDto GetMealById(int id);
    int CreateMeal(CreateMealDto dto, int mealPlanId);
    void UpdateMeal(UpdateMealDto dto, int id);
    void DeleteMeal(int id);
}

public class MealService : IMealService
{
    private readonly IMapper _mapper;
    private readonly EatFormDbContext _dbContext;

    public MealService(IMapper mapper, EatFormDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public IEnumerable<MealDto> GetAllMeals()
    {
        var meals = _dbContext.Meals
            .Include(m => m.MealProducts)
                .ThenInclude(mp => mp.Product)
            .ToList();

        return _mapper.Map<IEnumerable<MealDto>>(meals);
    }

    public MealDto GetMealById(int id)
    {
        var meal = _dbContext.Meals
            .Include(m => m.MealProducts)
                .ThenInclude(mp => mp.Product)
            .FirstOrDefault(m => m.Id == id);

        if (meal == null)
            throw new Exception("Meal not found");

        return _mapper.Map<MealDto>(meal);
    }

    public int CreateMeal(CreateMealDto dto, int mealPlanId)
    {
        var meal = new Meal
        {
            Name = dto.Name,
            Time = dto.Time,
            MealPlanId = mealPlanId,
            TotalCalories = 0
        };

        _dbContext.Meals.Add(meal);
        _dbContext.SaveChanges();

        // Dodaj powiązania z produktami
        if (dto.Products != null && dto.Products.Count > 0)
        {
            foreach (var p in dto.Products)
            {
                var mealProduct = _mapper.Map<MealProduct>(p);
                mealProduct.MealId = meal.Id;

                // Wczytaj Product z bazy i przypisz do MealProduct
                mealProduct.Product = _dbContext.Products
                                          .FirstOrDefault(pr => pr.Id == mealProduct.ProductId)
                                      ?? throw new Exception($"Product with Id {mealProduct.ProductId} not found");

                _dbContext.MealProducts.Add(mealProduct);
            }

            _dbContext.SaveChanges();
        }

        // Przeliczenie kalorii
        var mealProductsWithProducts = _dbContext.MealProducts
            .Include(mp => mp.Product)
            .Where(mp => mp.MealId == meal.Id)
            .ToList();

        meal.TotalCalories = mealProductsWithProducts
            .Sum(mp => (mp.Quantity / 100.0) * mp.Product.Calories);

        _dbContext.SaveChanges();

        return meal.Id;
    }

    public void UpdateMeal(UpdateMealDto dto, int id)
    {
        var meal = _dbContext.Meals
            .Include(m => m.MealProducts)
            .FirstOrDefault(m => m.Id == id);

        if (meal == null)
            throw new Exception("Meal not found");

        // Aktualizacja danych podstawowych
        if (dto.Name != null)
            meal.Name = dto.Name;

        if (dto.Time.HasValue)
            meal.Time = dto.Time.Value;

        // Aktualizacja produktów
        if (dto.Products != null)
        {
            // Usuwamy stare
            var oldProducts = _dbContext.MealProducts.Where(mp => mp.MealId == id);
            _dbContext.MealProducts.RemoveRange(oldProducts);
            _dbContext.SaveChanges();

            // Dodajemy nowe
            foreach (var p in dto.Products)
            {
                var mealProduct = _mapper.Map<MealProduct>(p);
                mealProduct.MealId = id;

                // Wczytaj Product z bazy
                mealProduct.Product = _dbContext.Products
                                          .FirstOrDefault(pr => pr.Id == mealProduct.ProductId)
                                      ?? throw new Exception($"Product with Id {mealProduct.ProductId} not found");

                _dbContext.MealProducts.Add(mealProduct);
            }

            _dbContext.SaveChanges();
        }

        // Przelicz kalorie
        var mealProductsWithProducts = _dbContext.MealProducts
            .Include(mp => mp.Product)
            .Where(mp => mp.MealId == id)
            .ToList();

        meal.TotalCalories = mealProductsWithProducts
            .Sum(mp => (mp.Quantity / 100.0) * mp.Product.Calories);

        _dbContext.SaveChanges();
    }


    public void DeleteMeal(int id)
    {
        var meal = _dbContext.Meals.FirstOrDefault(m => m.Id == id);

        if (meal == null)
            throw new Exception("Meal not found");

        var mealProducts = _dbContext.MealProducts.Where(mp => mp.MealId == id);
        _dbContext.MealProducts.RemoveRange(mealProducts);

        _dbContext.Meals.Remove(meal);
        _dbContext.SaveChanges();
    }
}
