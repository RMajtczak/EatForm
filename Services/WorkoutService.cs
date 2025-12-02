using AutoMapper;
using EatForm.Entities;
using EatForm.Models;
using Microsoft.EntityFrameworkCore;

namespace EatForm;
public interface IWorkoutService
{
    public IEnumerable<WorkoutDto> GetAllWorkouts();
    public WorkoutDto GetWorkoutById(int id);
    int CreateWorkout(CreateWorkoutDto dto);
    public void UpdateWorkout(int id, WorkoutDto dto);
    public void DeleteWorkout(int id);
}
public class WorkoutService: IWorkoutService
{
    private readonly IMapper _mapper;
    private readonly EatFormDbContext _dbcontext;
    
    public WorkoutService(IMapper mapper, EatFormDbContext context)
    {
        _mapper = mapper;
        _dbcontext = context;
    }
    
    public IEnumerable<WorkoutDto> GetAllWorkouts()
    {
        var workouts = _dbcontext.Workouts.ToList();
        return _mapper.Map<IEnumerable<WorkoutDto>>(workouts);
    }
    
    public WorkoutDto GetWorkoutById(int id)
    {
        var workout = _dbcontext.Workouts.FirstOrDefault(w => w.Id == id);
        if(workout == null)
            throw new Exception("Wrokout not found");
        var workoutDto = _mapper.Map<WorkoutDto>(workout);
        return workoutDto;
    }
    
    public int CreateWorkout(CreateWorkoutDto dto)
    {
        var workout = _mapper.Map<Workout>(dto);
        _dbcontext.Workouts.Add(workout);
        _dbcontext.SaveChanges();

        return workout.Id;
    }
    
    public void UpdateWorkout(int id, WorkoutDto dto)
    {
        var workout = _dbcontext.Workouts.FirstOrDefault(w => w.Id == id);
        if (workout == null) 
            throw new Exception("Workout not found");
        
        _mapper.Map(dto, workout);
        _dbcontext.SaveChanges();
    }
    
    public void DeleteWorkout(int id)
    {
        var workout = _dbcontext.Workouts.FirstOrDefault(w => w.Id == id);
        if (workout == null) 
            throw new Exception("Workout not found");
        _dbcontext.Workouts.Remove(workout);
        _dbcontext.SaveChanges();
    }
}