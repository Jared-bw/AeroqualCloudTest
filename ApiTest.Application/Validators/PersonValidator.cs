using ApiTest.Application.Models;
using FluentValidation;

namespace ApiTest.Application.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Id)
            .GreaterThanOrEqualTo(0);

        RuleFor(p => p.Age)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Age must be greater than or equal to 0");

        RuleFor(p => p.Name)
            .NotEmpty();
    }
}