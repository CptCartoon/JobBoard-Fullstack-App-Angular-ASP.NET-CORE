using FluentValidation;
using JobBoardBackend.Entities;

namespace JobBoardBackend.Models.Validators
{
    public class RegisterClientValidator : AbstractValidator<RegisterClientDto>
    {
        public RegisterClientValidator(JobBoardDbContext dbContext) 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(5);

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                   var emailInUse = dbContext.UserLogin.Any(u =>  u.Email == value);

                    if(emailInUse)
                    {
                        context.AddFailure("Email", "Email is already in use");
                    }
                });
        }
    }
}
