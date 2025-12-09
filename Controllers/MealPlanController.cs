using EatForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EatForm.Controllers;
[Route("api/mealplans")]
[ApiController]
public class MealPlanController : ControllerBase
{
    private readonly IMealPlanService _mealPlanService;
    
    public MealPlanController(IMealPlanService mealPlanService)
    {
        _mealPlanService = mealPlanService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<MealPlanDto>> GetAll()
    {
        var mealPlanDtos = _mealPlanService.GetAll();
        return Ok(mealPlanDtos);
    }
    [HttpGet("{id}")]
    public ActionResult<MealPlanDto> GetById([FromRoute] int id)
    {
        var mealPlanDto = _mealPlanService.GetById(id);
        return Ok(mealPlanDto);
    }
    [HttpPost]
    public ActionResult CreateMealPlan([FromBody] CreateMealPlanDto dto)
    {
        var newMealPlanId = _mealPlanService.CreateMealPlan(dto);
        return Created($"/api/mealplans/{newMealPlanId}", null);
    }
    [HttpPut("{id}")]
    public ActionResult UpdateMealPlan([FromBody] UpdateMealPlanDto dto, [FromRoute] int id)
    {
        _mealPlanService.UpdateMealPlan(dto, id);
        return Ok();
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteMealPlan([FromRoute] int id)
    {
        _mealPlanService.DeleteMealPlan(id);
        return NoContent();
    }
}