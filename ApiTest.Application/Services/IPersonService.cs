using ApiTest.Application.Models;

namespace ApiTest.Application.Services;

public interface IPersonService
{
    public Task<bool> CreateAsync(Person person, CancellationToken token = default);
    public Task<Person?> GetByIdAsync(int id, CancellationToken token = default);
    public Task<IEnumerable<Person>> GetAllAsync(GetAllPersonsOptions opt, CancellationToken? token = default);
    public Task<Person?> UpdateAsync(Person person, CancellationToken token = default);
    public Task<bool> DeleteByIdAsync(int id, CancellationToken token = default);
    public int GetNextId();
}