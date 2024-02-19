using System.Text.Json.Nodes;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RainFallApi.ApiProvider;
using RainFallApi.Endpoints.Response;

namespace RainFallApi;

public class UKRainFallApiProvider : IRainFallApiProvider
{
    private string providerURL => Environment.GetEnvironmentVariable("rain_fall_api_provider");
    private readonly string apiRoute = "flood-monitoring/id/stations/{0}/readings";

    private readonly Serilog.ILogger _logger;

    public UKRainFallApiProvider(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public async Task<RainfallReadingResponse> Read(string stationId, int limit)
    {
        try
        {
            _logger.Information("Started Api Integration");

            var uri = new Uri(string.Format($"{providerURL}/{apiRoute}", stationId));
            var rawResult = await uri
                .SetQueryParam("_limit", limit)
                .SetQueryParam("_sorted")
                .GetStringAsync();

            _logger.Information("Api request is sucessful");

            _logger.Information("Trying to parse response");
            var rawResponse = JsonConvert.DeserializeObject<JObject>(rawResult);
            var rawResponseObject = rawResponse["items"]?.ToObject<List<RawResponseModel>>();

            _logger.Information("Success reponse parsing");

            if (rawResponseObject != null && rawResponseObject.Any())
            {
                var readings = rawResponseObject.Select(x => new RainfallReading
                {
                    AmountMeasured = (decimal)x.Value,
                    DateMeasured = x.DateTime
                }).ToList();

                return new RainfallReadingResponse
                {
                    Readings = readings
                };
            }
            else
            {
                _logger.Warning("No Reading was found.");
                return null;
            }
        }
        catch (FlurlHttpException flurlEx)
        {
            _logger.Error(flurlEx.Message, flurlEx);

            throw;
        }
    }
}
