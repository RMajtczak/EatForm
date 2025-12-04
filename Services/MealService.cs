using AutoMapper;
using EatForm.Entities;
using EatForm.Models;
using Microsoft.EntityFrameworkCore;

namespace EatForm;

public interface IMealService
{
    IEnumerable<MealDto> GetAllMeals();
    MealDto GetMealById(int id);
    MealDto CreateMeal(CreateMealDto createMealDto);
    void UpdateMeal(int id, UpdateMealDto updateMealDto);
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

        return _mapper.Map<List<MealDto>>(meals);
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
    
    public MealDto CreateMeal(CreateMealDto dto)
    {
        var meal = new Meal
        {
            Name = dto.Name,
            Time = dto.Time,
            MealProducts = dto.Products.Select(p => new MealProduct
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList()
        };

        _dbContext.Meals.Add(meal);
        _dbContext.SaveChanges();

        return _mapper.Map<MealDto>(meal);
    }
    
    public void UpdateMeal(int id, UpdateMealDto dto)
    {
        var meal = _dbContext.Meals
            .Include(m => m.MealProducts)
            .FirstOrDefault(m => m.Id == id);

        if (meal == null)
            throw new Exception("Meal not found");

        // Aktualizacja prostych pól
        meal.Name = dto.Name;
        meal.Time = dto.Time;

        // Usuwamy stare produkty
        _dbContext.MealProducts.RemoveRange(meal.MealProducts);

        // Dodajemy nowe
        if (dto.Products != null)
            meal.MealProducts = dto.Products.Select(p => new MealProduct
            {
                ProductId = p.ProductId,
                Quantity = (double)p.Quantity
            }).ToList();

        _dbContext.SaveChanges();
    }
    
    public void DeleteMeal(int id)
    {
        var meal = _dbContext.Meals
            .Include(m => m.MealProducts)
            .FirstOrDefault(m => m.Id == id);

        if (meal == null)
            return;

        // najpierw usuwamy powiązane produkty
        _dbContext.MealProducts.RemoveRange(meal.MealProducts);

        // potem sam posiłek
        _dbContext.Meals.Remove(meal);

        _dbContext.SaveChanges();
    }
}
