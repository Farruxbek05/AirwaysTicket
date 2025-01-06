using Airways.Core.Entity;
using FluentValidation;

namespace Airways.Application.Validators
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
