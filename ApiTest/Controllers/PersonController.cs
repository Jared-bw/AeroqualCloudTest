using System;
using System.Threading;
using System.Threading.Tasks;
using ApiTest.Application.Models;
using ApiTest.Application.Services;
using ApiTest.Contracts.Requests;
using ApiTest.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers;

[ApiController]
public class PersonController: ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    
    [HttpGet(ApiEndpoints.People.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPersonsRequest req,
        CancellationToken token)
    {
        // TODO: add pagination
        var options = req.MapToOptions();
        var people = await _personService.GetAllAsync(options);

        var response = people.ToPersonResponses();
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.People.Get)]
    public async Task<IActionResult> Get([FromRoute] int id,
        CancellationToken token)
    {
        var person = await _personService.GetByIdAsync(id, token);

        if (person is null)
        {
            return NotFound();
        }

        var response = person.ToPersonResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.People.Delete)]
    public async Task<IActionResult> DeletePerson([FromRoute] int id,
        CancellationToken token)
    {
        var isDeleted = await _personService.DeleteByIdAsync(id, token);

        if (!isDeleted)
        {
            return NotFound();
        }
        
        return Ok();
    }

    [HttpPost(ApiEndpoints.People.Create)]
    public async Task<IActionResult> CreatePerson([FromBody] CreatePersonRequest request,
        CancellationToken token = default)
    {
        var nextId = _personService.GetNextId();
            
        var person = request.MapToPerson(nextId);

        await _personService.CreateAsync(person, token);

        var personResponse = person.ToPersonResponse();
        return CreatedAtAction(nameof(Get), new { id = person.Id}, personResponse);
    }

    [HttpPut(ApiEndpoints.People.Update)]
    public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonRequest request,
        CancellationToken token)
    {
        var person = request.MapToPerson();

        var updatedPerson = await _personService.UpdateAsync(person, token);
        if (updatedPerson is null)
        {
            return NotFound();
        }

        var response = person.ToPersonResponse();
        return Ok(response);
    }

}