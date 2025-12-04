using AutoMapper;
using EatForm.Entities;
using EatForm.Models;

namespace EatForm;

public class EatFormMappingProfile : Profile
{
    public EatFormMappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, value) => value != null)); 
        
        CreateMap<Meal, MealDto>();
        CreateMap<CreateMealDto, Meal>();
        CreateMap<UpdateMealDto, Meal>()
            .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
        
        CreateMap<MealProduct, MealProductDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Calories, opt => opt.MapFrom(src => src.Product.Calories))
            .ForMember(dest => dest.Protein, opt => opt.MapFrom(src => src.Product.Protein))
            .ForMember(dest => dest.Carbs, opt => opt.MapFrom(src => src.Product.Carbs))
            .ForMember(dest => dest.Fat, opt => opt.MapFrom(src => src.Product.Fat));
        CreateMap<CreateMealProductDto, MealProduct>();
        CreateMap<UpdateMealProductDto, MealProduct>()
            .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
        
        CreateMap<MealPlan, MealPlanDto>();
        CreateMap<CreateMealPlanDto, MealPlan>();
        CreateMap<UpdateMealPlanDto, MealPlan>()
            .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));

        CreateMap<Exercise, ExerciseDto>();
        CreateMap<CreateExerciseDto, Exercise>();
        CreateMap<UpdateExerciseDto, Exercise>()
            .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
        
        CreateMap<Workout, WorkoutDto>();
        CreateMap<WorkoutDto, Workout>()
            .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
        CreateMap<CreateWorkoutDto, Workout>();
        CreateMap<UpdateWorkoutDto, Workout>()
            .ForAllMembers(opt => opt.Condition((src, dest, value) => value != null));
    }
}