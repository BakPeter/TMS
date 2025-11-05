using Microsoft.Extensions.DependencyInjection;
using Repository.Core.Interfaces;
using Repository.Core.Interfaces.Validation;
using Repository.Infrastructure.Ioc;
using TMS.Core.Interfaces;
using TMS.Core.Types;
using TMS.Infrastructure.Interfaces;
using TMS.Infrastructure.Services;
using TMS.Infrastructure.Services.Validators;

namespace TMS.Infrastructure.Ioc;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddTmsServices(this IServiceCollection services)
    {
        services.AddRepositoryServices<Ticket>();

        services.AddSingleton<IRepositoryAdapter<Ticket>, CachedEntityRepositoryAdapter>();
        services.AddTransient<ITicketService, TicketService>();
        services.AddTransient<IEntityValidator<Ticket>, TicketSubjectValidator>();
        services.AddSingleton<IIdGenerator, IdGenerator>();

        return services;
    }
}