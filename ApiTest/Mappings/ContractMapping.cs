using System.Collections.Generic;
using System.Linq;
using ApiTest.Application.Models;
using ApiTest.Contracts.Requests;
using ApiTest.Contracts.Responses;

namespace ApiTest.Mappings;

public static class ContractMapping
{
    public static Person MapToPerson(this CreatePersonRequest req, int nextId)
    {
        var person = new Person
        {
            Id = nextId,
            Age = req.Age,
            Name = req.Name
        };

        return person;
    }

    public static Person MapToPerson(this UpdatePersonRequest req)
    {
        var person = new Person
        {
            Id = req.Id,
            Age = req.Age,
            Name = req.Name
        };

        return person;
    }
    
    public static PersonResponse ToPersonResponse(this Person person)
    {
        var response = new PersonResponse
        {
            Age = person.Age,
            Id = person.Id,
            Name = person.Name,
        };
        return response;
    }

    public static IEnumerable<PersonResponse> ToPersonResponses(this IEnumerable<Person> people)
    {
        return people.Select(ToPersonResponse);
    }

    public static GetAllPersonsOptions MapToOptions(this GetAllPersonsRequest req)
    {
        var options = new GetAllPersonsOptions
        {
            Name = req.Name,
            Page = req.Page,
            PageSize = req.PageSize
        };
        return options;
    }
}