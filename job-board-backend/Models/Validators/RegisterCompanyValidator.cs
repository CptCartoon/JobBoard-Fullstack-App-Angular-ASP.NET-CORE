using FluentValidation;
using JobBoardBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobBoardBackend.Models.Validators
{
    public class RegisterCompanyValidator : AbstractValidator<RegisterCompanyDto>
    {
        public RegisterCompanyValidator(AuthorizationDbContext dbContext) {
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
                        var emailInUse = dbContext.UserLogin.Any(u => u.Email == value);

                        if (emailInUse)
                        {
                            context.AddFailure("Email", "Email is already in use");
                        }
                    });
        }
    }
}
