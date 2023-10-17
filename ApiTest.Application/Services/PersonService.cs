using ApiTest.Application.Models;
using ApiTest.Application.Repository;
using FluentValidation;

namespace ApiTest.Application.Services;

public class PersonService: IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IValidator<Person> _validator;
    private readonly IValidator<GetAllPersonsOptions> _optionsValidator;

    public PersonService(IPersonRepository personRepository, IValidator<Person> validator, IValidator<GetAllPersonsOptions> optionsValidator)
    {
        _personRepository = personRepository;
        _validator = validator;
        _optionsValidator = optionsValidator;
    }

    public async Task<bool> CreateAsync(Person person, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(person, token);
        return await _personRepository.CreateAsync(person, token);
    }

    public Task<Person?> GetByIdAsync(int id, CancellationToken token = default)
    {
        return _personRepository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<Person>> GetAllAsync(GetAllPersonsOptions opt, CancellationToken? token = default)
    {
        await _optionsValidator.ValidateAndThrowAsync(opt);
        return _personRepository.GetAll(opt, token);
    }

    public async Task<Person?> UpdateAsync(Person person, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(person, token);
        return await _personRepository.UpdateAsync(person, token);
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken token = default)
    {
        return _personRepository.DeleteByIdAsync(id, token);
    }

    public int GetNextId()
    {
        return _personRepository.GetNextId();
    }
}