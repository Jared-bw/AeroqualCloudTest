using ApiTest.Application.Models;
using FluentValidation;

namespace ApiTest.Application.Validators;

public class GetAllPersonsOptionsValidator : AbstractValidator<GetAllPersonsOptions>
{
    public GetAllPersonsOptionsValidator()
    {
        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 25);

        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1);
    }
}