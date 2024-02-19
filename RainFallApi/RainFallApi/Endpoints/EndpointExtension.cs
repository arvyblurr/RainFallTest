// using System.Reflection;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.OpenApi.Any;
// using Microsoft.OpenApi.Models;

// namespace RainFallApi.Endpoints;

// public static class EndpointExtension
// {
//     public static void ConfigurationEndpoint(this WebApplication app)
//     {
        
//         app.MapGet("rainfall/id/{stationId}/readings", (HttpContext context) =>
//         {

//         })
//         .WithOpenApi(x =>
//         {
//             x.Summary = "Get rainfall readings by station Id";
//             x.Description = "Retrieve the latest readings for the specified stationId";
//             x.Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Rainfall" } };
//             x.OperationId = "get-rainfall";
//             x.Parameters.Add(new OpenApiParameter
//             {
//                 Name = "stationId",
//                 Description = "The id of the reading station.",
//                 Required = true,
//                 In = ParameterLocation.Path,
//                 Style = ParameterStyle.Simple,
//                 Schema = new OpenApiSchema
//                 {
//                     Type = "string"
//                 }
//             });

//             x.Parameters.Add(new OpenApiParameter
//             {
//                 Name = "count",
//                 Description = "The number of readings to return",
//                 Required = false,
//                 In = ParameterLocation.Query,
//                 Style = ParameterStyle.Simple,
//                 Schema = new OpenApiSchema
//                 {
//                     Type = "number",
//                     Minimum = 1,
//                     Maximum = 100,
//                     Default = new OpenApiDouble(10)
//                 },
//             });

//             // Update the default 200 response
//             if (x.Responses.ContainsKey("200"))
//             {
//                 var response = x.Responses["200"];
//                 response.Description = "A list of rainfall readings successfully retrieved";

//                 response.Content = new Dictionary<string, OpenApiMediaType>
//                 {
//                     ["application/json"] = new OpenApiMediaType
//                     {
//                         Schema = new OpenApiSchema
//                         {
//                             Reference = new OpenApiReference
//                             {
//                                 Type = ReferenceType.Schema,
//                                 Id = "#/components/responses/rainfallReadingResponse"
//                             }
//                         }
//                     }
//                 };
//             }

//             x.Responses.Add("404", new OpenApiResponse
//             {
//                 Description = "No readings found for the specified stationId",
//                 Content = new Dictionary<string, OpenApiMediaType>
//                 {
//                     ["application/json"] = new OpenApiMediaType
//                     {
//                         Schema = new OpenApiSchema
//                         {
//                             Reference = new OpenApiReference
//                             {
//                                 Type = ReferenceType.Schema,
//                                 Id = "#/components/responses/errorResponse"
//                             }
//                         }
//                     }
//                 }
//             });
//             x.Responses.Add("500", new OpenApiResponse
//             {
//                 Description = "Internal server error",
//                 Content = new Dictionary<string, OpenApiMediaType>
//                 {
//                     ["application/json"] = new OpenApiMediaType
//                     {
//                         Schema = new OpenApiSchema
//                         {
//                             Reference = new OpenApiReference
//                             {
//                                 Type = ReferenceType.Schema,
//                                 Id = "#/components/responses/errorResponse"
//                             }
//                         }
//                     }
//                 }
//             });


//             return x;
//         });
//     }
// }
