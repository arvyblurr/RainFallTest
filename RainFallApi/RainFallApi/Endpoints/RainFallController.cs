using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using RainFallApi.Endpoints.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace RainFallApi.Endpoints;

[ApiController]
[Route("")]
public class RainFallController : ControllerBase
{
    private IRainFallApiProvider _rainFallApiProvider;

    public RainFallController(IRainFallApiProvider rainFallApiProvider)
    {
        _rainFallApiProvider = rainFallApiProvider;
    }

    [HttpGet("rainfall/id/{stationId}/readings")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType(typeof(Response.Responses))]
    [SwaggerOperation(
        Summary = "Get rainfall readings by station Id",
        Description = "Retrieve the latest readings for the specified stationId",
        OperationId = "get-rainfall",
        Tags = ["Rainfall"]
    )]
    public async Task<IActionResult> GetRainFallReading(
        [FromRoute, SwaggerParameter(
            Required = true,
            Description = "The id of the reading station"),
            ] string stationId,
        [FromQuery, SwaggerParameter(
            Required = false,
            Description = "The number of readings to return"),
            Range(1, 100)] int count = 10)
    {

        try
        {
            var result = await _rainFallApiProvider.Read(stationId, count);

            if (result == null)
                return NotFound(new Error
                {
                    Message = "No readings found for the specified stationId"
                });
            else
                return Ok(result);
        }
        catch{

            return StatusCode(500, "Internal Server Error");
        }
    }
}