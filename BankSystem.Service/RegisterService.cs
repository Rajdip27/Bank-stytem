using BankSystem.Service.Repository;
using BankSystem.Service.Repository.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankSystem.Service;

public static class RegisterService
{
    public static IServiceCollection ApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(x =>
        {
            x.AddMaps(typeof(IApplication).Assembly);

        });
        // services.AddValidatorsFromAssembly(typeof(IApplication).Assembly);
        services.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
        //services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IUserRepository, UserRepository>();


        services.Scan(scan => scan.FromAssemblyOf<IApplication>()
            .AddClasses(classes => classes.AssignableTo<IApplication>())
            .AddClasses(x => x.AssignableTo(typeof(IBaseRepository<,,>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

        return services;
    }
}