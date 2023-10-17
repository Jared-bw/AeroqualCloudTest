using ApiTest.Application.Models;
using JsonFlatFileDataStore;

namespace ApiTest.Application.Database;

public class PersonDocumentFactory
{
    private readonly DataStore _dataStore;

    public PersonDocumentFactory(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public IDocumentCollection<Person> CreatePersonDocumentCollection()
    {
        var collection = _dataStore.GetCollection<Person>("People");
        return collection;
    }
}