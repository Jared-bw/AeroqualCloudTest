namespace ApiTest.Contracts.Responses;

public class PersonResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required int Age { get; init; }
}