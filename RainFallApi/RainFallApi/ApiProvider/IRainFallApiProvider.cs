using RainFallApi.Endpoints.Response;

namespace RainFallApi;

public interface IRainFallApiProvider
{
    Task<RainfallReadingResponse> Read(string stationId, int limit);
}
