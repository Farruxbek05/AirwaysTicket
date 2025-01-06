using Airways.Core.Entity;
using FluentValidation;

namespace Airways.Application.Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user)
                .NotEmpty();
        }
    }
}
