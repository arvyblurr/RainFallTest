using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace RainFallApi.Configurations.Swagger;

public static class SwaggerExtenstion
{
    public static void ConfigurationSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Rainfall Api",
                Version = "1.0",
                Contact = new OpenApiContact
                {
                    Name = "Sorted",
                    Url = new Uri("https://www.sorted.com")
                },
                Description = "An API which provides rainfall reading data",
            });
            c.AddServer(new OpenApiServer
            {
                Url = "http://localhost:3000",
                Description = "Rainfall Api"
            });

            c.EnableAnnotations();

            c.SchemaFilter<SwaggerRainfallReadingResponseSchemaFilter>();

            c.OperationFilter<SwaggerRainfallReadingResponsesOperationFilter>();
        });

        services.AddSwaggerGenNewtonsoftSupport();

    }

}
