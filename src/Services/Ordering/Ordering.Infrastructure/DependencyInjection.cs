﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")!;

        // Add Services to Container
        services.AddScoped<ISaveChangesInterceptor,AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor,DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, opts) =>
        {
            opts.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            opts.UseSqlServer(connectionString);
        });
        //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }
}
