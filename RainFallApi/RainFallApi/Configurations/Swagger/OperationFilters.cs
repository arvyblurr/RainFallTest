using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RainFallApi;

public class SwaggerRainfallReadingResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Responses.TryGetValue("200", out OpenApiResponse response))
        {
            response.Description = "A list of rainfall readings successfully retrieved";
        }
        if (operation.Responses.TryGetValue("400", out OpenApiResponse response400))
        {
            response400.Description = "Invalid request";
        }
        if (operation.Responses.TryGetValue("404", out OpenApiResponse response404))
        {
            response404.Description = "No readings found for the specified stationId";
        }
        if (operation.Responses.TryGetValue("500", out OpenApiResponse response500))
        {
            response500.Description = "Internal server error";
        }

    }
}
