using EatForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EatForm.Controllers;
[Route("api/exercises")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;
    
    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ExerciseDto>> GetAll()
    {
        var exerciseDtos = _exerciseService.GetAllExercises();
        return Ok(exerciseDtos);
    }
    
    [HttpGet ("{id}")]
    public ActionResult<ExerciseDto> GetById([FromRoute] int id)
    {
        var exerciseDto = _exerciseService.GetExerciseById(id);
        return Ok(exerciseDto);
    }
    
    [HttpPost]
    public ActionResult CreateExercise([FromBody] CreateExerciseDto dto)
    {
        var id = _exerciseService.CreateExercise(dto);
        return Created($"/api/exercise/{id}", null);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateExercise([FromBody] UpdateExerciseDto dto, [FromRoute] int id)
    {
        _exerciseService.UpdateExercise(dto, id);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteExercise([FromRoute] int id)
    {
        _exerciseService.DeleteExercise(id);
        return NoContent();
    }
    
}