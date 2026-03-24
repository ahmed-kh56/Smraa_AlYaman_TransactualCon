


namespace Smraa_AlYaman.Api;

public static class DependencyInjection
{
    private static IServiceCollection AddPresentationDocumentation(this IServiceCollection services)
    {
        // Controllers
        services.AddControllers();

        // Swagger + OpenAPI metadata
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Problem details for consistent error responses
        services.AddProblemDetails();
        services.AddControllers();
        // Access to HttpContext outside controllers
        services.AddHttpContextAccessor();


        return services;
    }
    private static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        return services
            .AddPresentationDocumentation()
            .AddCorsPolicy();
    }





}
