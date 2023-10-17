namespace ApiTest.Contracts.Requests;

public class GetAllPersonsRequest : IPagedRequest
{
    public string? Name { get; init; }
    public required int Page { get; init; } = 1;
    public required int PageSize { get; init; } = 10;
}