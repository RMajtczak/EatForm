using EatForm.Entities;
using FluentValidation;

namespace EatForm.Models.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator(EatFormDbContext dbContext)
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).MinimumLength(6).WithMessage("Hasło musi mieć co najmniej 6 znaków");
        RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
        RuleFor(x => x.Email)
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });

    }
}