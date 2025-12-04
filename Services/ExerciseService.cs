using AutoMapper;
using EatForm.Entities;
using EatForm.Models;

namespace EatForm;
public interface IExerciseService
{
    IEnumerable<ExerciseDto> GetAllExercises();
    ExerciseDto GetExerciseById(int id);
    int CreateExercise(CreateExerciseDto dto);
    void UpdateExercise(UpdateExerciseDto dto, int id);
    void DeleteExercise(int id);
}
public class ExerciseService : IExerciseService
{
    private readonly IMapper _mapper;
    private readonly EatFormDbContext _dbContext;
    
    public ExerciseService(IMapper mapper, EatFormDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public IEnumerable<ExerciseDto> GetAllExercises()
    {
        var exercises = _dbContext.Exercises.ToList();
        var exerciseDtos = _mapper.Map<List<ExerciseDto>>(exercises);
        return exerciseDtos;
    }
    
    public ExerciseDto GetExerciseById(int id)
    {
        var exercise = _dbContext.Exercises.FirstOrDefault(e => e.Id == id);
        if (exercise == null)
            throw new Exception("Exercise not found");
        var exerciseDto = _mapper.Map<ExerciseDto>(exercise);
        return exerciseDto;
    }
    
    public int CreateExercise(CreateExerciseDto dto)
    {
        var exercise = _mapper.Map<Exercise>(dto);
        _dbContext.Exercises.Add(exercise);
        _dbContext.SaveChanges();
        
        return exercise.Id;
    }
    
    public void UpdateExercise(UpdateExerciseDto dto, int id)
    {
        var exercise = _dbContext.Exercises.FirstOrDefault(e => e.Id == id);
        if (exercise == null)
            throw new Exception("Exercise not found");
        _mapper.Map(dto, exercise);
        _dbContext.SaveChanges();
    }
    
    public void DeleteExercise(int id)
    {
        var exercise = _dbContext.Exercises.FirstOrDefault(e => e.Id == id);
        if (exercise == null)
            throw new Exception("Exercise not found");
        
        _dbContext.Exercises.Remove(exercise);
        _dbContext.SaveChanges();
    }
    
}