using AutoMapper;
using EatForm.Entities;
using EatForm.Models;

namespace EatForm;

public interface IMealProductService
{
    IEnumerable<MealProductDto> GetAll();
    MealProductDto GetMealProductById(int id);
    int CreateMealProduct(CreateMealProductDto dto);
    void UpdateMealProduct(CreateMealProductDto dto, int id);
    void DeleteMealProduct(int id);
}
public class MealProductService : IMealProductService
{
    private readonly IMapper _mapper;
    private readonly EatFormDbContext _dbContext;
    
    public MealProductService(IMapper mapper, EatFormDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public IEnumerable<MealProductDto> GetAll()
    {
        var mealProducts = _dbContext.MealProducts;
        var mealProductDtos = _mapper.Map<IEnumerable<MealProductDto>>(mealProducts);
        return mealProductDtos;
    }

    public MealProductDto GetMealProductById(int id)
    {
        var mealProduct = _dbContext.MealProducts.FirstOrDefault(mp => mp.Id == id);
        if (mealProduct == null)
            throw new Exception("MealProduct not found");
        var mealProductDto = _mapper.Map<MealProductDto>(mealProduct);
        return mealProductDto;
    }
    public int CreateMealProduct(CreateMealProductDto dto)
    {
        var mealProduct = _mapper.Map<MealProduct>(dto);
        _dbContext.MealProducts.Add(mealProduct);
        _dbContext.SaveChanges();
        return mealProduct.Id;
    }
    public void UpdateMealProduct(CreateMealProductDto dto, int id)
    {
        var mealProduct = _dbContext.MealProducts.FirstOrDefault(mp => mp.Id == id);
        if (mealProduct == null)
            throw new Exception("MealProduct not found");
        _mapper.Map(dto, mealProduct);
        _dbContext.SaveChanges();
    }
    public void DeleteMealProduct(int id)
    {
        var mealProduct = _dbContext.MealProducts.FirstOrDefault(mp => mp.Id == id);
        if (mealProduct == null)
            throw new Exception("MealProduct not found");
        _dbContext.MealProducts.Remove(mealProduct);
        _dbContext.SaveChanges();
    }
    
}