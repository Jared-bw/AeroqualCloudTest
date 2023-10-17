namespace ApiTest.Application.Models;

public class GetAllPersonsOptions
{
    public string? Name { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}