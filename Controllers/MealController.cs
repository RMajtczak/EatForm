using EatForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EatForm.Controllers;
[Route("api/meals")]
[ApiController]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;
    
    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<MealDto>> GetAll()
    {
        var mealDtos = _mealService.GetAllMeals();
        return Ok(mealDtos);
    }
    [HttpGet("{id}")]
    public ActionResult<MealDto> GetById([FromRoute] int id)
    {
        var mealDto = _mealService.GetMealById(id);
        return Ok(mealDto);
    }
    [HttpPost]
    public ActionResult CreateMeal([FromBody] CreateMealDto dto)
    {
        var mealDto = _mealService.CreateMeal(dto);
        return Created($"/api/meals/{mealDto.Id}", null);
    }
    [HttpPut("{id}")]
    public ActionResult UpdateMeal([FromBody] UpdateMealDto dto, [FromRoute] int id)
    {
        _mealService.UpdateMeal(id, dto);
        return Ok();
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteMeal([FromRoute] int id)
    {
        _mealService.DeleteMeal(id);
        return NoContent();
    }
}