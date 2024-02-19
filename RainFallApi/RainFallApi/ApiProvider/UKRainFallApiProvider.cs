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

    public async Task<RainfallReadingResponse> Read(string stationId, int limit)
    {
        try
        {
            var uri = new Uri(string.Format($"{providerURL}/{apiRoute}", stationId));
            var rawResult = await uri
                .SetQueryParam("_limit", limit)
                .SetQueryParam("_sorted")
                .GetStringAsync();

            var rawResponse = JsonConvert.DeserializeObject<JObject>(rawResult);
            var rawResponseObject = rawResponse["items"]?.ToObject<List<RawResponseModel>>();

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
                return null;
            }
        }
        catch (FlurlHttpException flurlEx)
        {
            // Log or handle the exception appropriately
            throw; // Rethrow the exception to maintain the original stack trace
        }
    }
}
