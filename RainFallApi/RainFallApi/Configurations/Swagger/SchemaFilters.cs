using Microsoft.OpenApi.Models;
using RainFallApi.Endpoints;
using RainFallApi.Endpoints.Response;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RainFallApi.Configurations.Swagger;

public class SwaggerRainfallReadingResponseSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {

        if (context.Type == typeof(RainfallReadingResponse))
        {
            schema.Title = "Rainfall reading response";
            schema.Type = "object";
            schema.Description = "Details of a rainfall reading";
        }
        else if (context.Type == typeof(RainfallReading))
        {
            schema.Title = "Rainfall reading";
            schema.Type = "object";
            schema.Description = "Details of a rainfall reading";

        }
        else if (context.Type == typeof(Error))
        {
            schema.Title = "Error response";
            schema.Type = "object";
            schema.Description = "Details of a rainfall reading";
        }
        else if (context.Type == typeof(ErrorDetail))
        {
            schema.Title = "Error response";
            schema.Type = "object";
            schema.Description = "Details of invalid request property";
        }
    }
}
