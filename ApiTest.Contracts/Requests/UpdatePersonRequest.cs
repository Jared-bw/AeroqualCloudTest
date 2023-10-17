namespace ApiTest.Contracts.Requests;

public class UpdatePersonRequest
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required int Age { get; init; }
}