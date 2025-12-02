using EatForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EatForm.Controllers;
[Route("api/mealproducts")]
[ApiController]
public class MealProductController : ControllerBase
{
    private readonly IMealProductService _mealProductService;
    
    public MealProductController(IMealProductService mealProductService)
    {
        _mealProductService = mealProductService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<MealProductDto>> GetAll()
    {
        var mealProductDtos = _mealProductService.GetAll();
        return Ok(mealProductDtos);
    }
    
    [HttpGet ("{id}")]
    public ActionResult<MealProductDto> GetById([FromRoute] int id)
    {
        var mealProductDto = _mealProductService.GetMealProductById(id);
        return Ok(mealProductDto);
    }
    [HttpPost]
    public ActionResult CreateMealProduct([FromBody] CreateMealProductDto dto)
    {
        var id = _mealProductService.CreateMealProduct(dto);
        return Created($"/api/mealproducts/{id}", null);
    }
    [HttpPut("{id}")]
    public ActionResult UpdateMealProduct([FromBody] CreateMealProductDto dto, [FromRoute] int id)
    {
        _mealProductService.UpdateMealProduct(dto, id);
        return Ok();
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteMealProduct([FromRoute] int id)
    {
        _mealProductService.DeleteMealProduct(id);
        return NoContent();
    }
    
}