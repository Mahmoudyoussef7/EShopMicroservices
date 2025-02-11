namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")!;

        // Add Services to Container
        //services.AddDbContext<ApplicationDbContext>(opts => opts.useSqlServer(connectionString));
        //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }
}
