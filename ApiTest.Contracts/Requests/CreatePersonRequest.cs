namespace ApiTest.Contracts.Requests;

public class CreatePersonRequest
{
    public required string Name { get; init; }
    public required int Age { get; init; }
}