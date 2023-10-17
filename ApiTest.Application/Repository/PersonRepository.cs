using ApiTest.Application.Database;
using ApiTest.Application.Models;

namespace ApiTest.Application.Repository;

public class PersonRepository: IPersonRepository
{
    private readonly PersonDocumentFactory _documentFactory;

    public PersonRepository(PersonDocumentFactory factory)
    {
        _documentFactory = factory;
    }


    public Task<bool> CreateAsync(Person person, CancellationToken token = default)
    {
        var documentCollection = _documentFactory.CreatePersonDocumentCollection();

        return documentCollection.InsertOneAsync(person);
    }

    public Task<Person?> GetByIdAsync(int id, CancellationToken token = default)
    {
        var documentCollection = _documentFactory.CreatePersonDocumentCollection();

        var person = documentCollection.AsQueryable().FirstOrDefault(p => p.Id == id);
        
        return Task.FromResult(person); // Left this as Task.FromResult because I had no idea if the query API for the Json file data access was async or not, I guess it isn't.
    }

    public IEnumerable<Person> GetAll(GetAllPersonsOptions options, CancellationToken? token = default)
    {
        var documentCollection = _documentFactory.CreatePersonDocumentCollection();

        var people = documentCollection.AsQueryable();
        if (options.Name is not null)
        {
            people = people.Where(p => p.Name.Contains(options.Name, StringComparison.OrdinalIgnoreCase));
        }

        var recordsToSkip = (options.Page - 1) * options.PageSize;
        people = people.Skip(recordsToSkip)
            .Take(options.PageSize);

        return people.ToList();
    }

    public async Task<Person?> UpdateAsync(Person person, CancellationToken token = default)
    {
        var documentCollection = _documentFactory.CreatePersonDocumentCollection();

        var personExists = await documentCollection.UpdateOneAsync(p => p.Id == person.Id, person);

        return personExists ? person : null;
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken token = default)
    {
        var documentCollection = _documentFactory.CreatePersonDocumentCollection();

        return documentCollection.DeleteOneAsync(p => p.Id == id);
    }

    public int GetNextId()
    {
        var documentCollection= _documentFactory.CreatePersonDocumentCollection();
        return documentCollection.GetNextIdValue();
    }
}