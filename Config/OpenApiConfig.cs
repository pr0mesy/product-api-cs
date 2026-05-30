using Microsoft.OpenApi.Models;

namespace ProductsAPI.Config;

public static class OpenApiConfig
{
    public static IServiceCollection AddOpenApiConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Products API",
                Version = "v1",
                Description = "RESTful API para gerenciamento de produtos"
            });
        });

        return services;
    }
}