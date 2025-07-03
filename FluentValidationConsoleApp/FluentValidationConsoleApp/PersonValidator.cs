using FluentValidation;

namespace FluentValidationConsoleApp
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Age).InclusiveBetween(0, 120).WithMessage("Age must be between 0 and 120.");
        }
    }
}
