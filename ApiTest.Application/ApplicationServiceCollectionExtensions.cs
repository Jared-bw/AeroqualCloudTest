using ApiTest.Application.Database;
using ApiTest.Application.Repository;
using ApiTest.Application.Services;
using FluentValidation;
using JsonFlatFileDataStore;
using Microsoft.Extensions.DependencyInjection;
namespace ApiTest.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IPersonRepository, PersonRepository>();
        services.AddSingleton<IPersonService, PersonService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string dataStorePath)
    {
        services.AddSingleton<PersonDocumentFactory>(_ => 
            new PersonDocumentFactory(new DataStore(dataStorePath, useLowerCamelCase: false)));
        return services;
    }
}