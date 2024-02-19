using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using RainFallApi.Endpoints.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace RainFallApi.Endpoints;

[ApiController]
[Route("")]
public class RainFallController : ControllerBase
{
    [HttpGet("rainfall/id/{stationId}/readings")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(rainfallReadingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(error), StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType(typeof(responses))]
    [SwaggerOperation(
        Summary = "Get rainfall readings by station Id",
        Description = "Retrieve the latest readings for the specified stationId",
        OperationId = "get-rainfall",
        Tags = ["Rainfall"] 
    )]
    public IActionResult GetRainFallReading(
        [FromRoute, SwaggerParameter(
            Required = true,
            Description = "The id of the reading station"),
            ] string stationId,
        [FromQuery, SwaggerParameter(
            Required = false,
            Description = "The number of readings to return"), 
            Range(1, 100)] uint count = 10)
    {
        
        return NotFound(new error());
    }
}