using ApiTest.Application.Models;

namespace ApiTest.Application.Repository;

public interface IPersonRepository
{
    public Task<bool> CreateAsync(Person person, CancellationToken token = default);
    public Task<Person?> GetByIdAsync(int id, CancellationToken token = default);
    public IEnumerable<Person> GetAll(GetAllPersonsOptions options, CancellationToken? token = default);
    public Task<Person?> UpdateAsync(Person person, CancellationToken token = default);
    public Task<bool> DeleteByIdAsync(int id, CancellationToken token = default);
    public int GetNextId();
}