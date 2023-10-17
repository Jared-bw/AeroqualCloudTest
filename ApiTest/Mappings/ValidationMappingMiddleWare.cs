using System.Linq;
using System.Threading.Tasks;
using ApiTest.Contracts.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ApiTest.Mappings;

public class ValidationMappingMiddleWare
{
    private readonly RequestDelegate _next;

    public ValidationMappingMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var validationFailureResponse = new ValidationFailureResponse
            {
                Errors = ex.Errors.Select(x => new ValidationResponse
                {
                    Message = x.ErrorMessage,
                    PropertyName = x.PropertyName,
                })
            };

            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
    
}
