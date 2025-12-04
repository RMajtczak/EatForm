using EatForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace EatForm.Controllers;
[Route("api/workouts")]
[ApiController]
public class WorkoutController: ControllerBase
{
    private readonly IWorkoutService _workoutService;
    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<WorkoutDto>> GetAll()
    {
        var workoutDtos = _workoutService.GetAllWorkouts();
        return Ok(workoutDtos);
    }
    [HttpGet("{id}")]
    public ActionResult<WorkoutDto> GetById([FromRoute] int id)
    {
        var workoutDto = _workoutService.GetWorkoutById(id);
        return Ok(workoutDto);
    }
    [HttpPost]
    public ActionResult CreateWorkout([FromBody] CreateWorkoutDto dto)
    {
        var id = _workoutService.CreateWorkout(dto);
        return Created($"/api/workouts/{id}", null);
    }
    [HttpPut("{id}")]
    public ActionResult UpdateWorkout([FromBody] UpdateWorkoutDto dto, [FromRoute] int id)
    {
        _workoutService.UpdateWorkout(dto, id);
        return Ok();
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteWorkout([FromRoute] int id)
    {
        _workoutService.DeleteWorkout(id);
        return NoContent();
    }
}