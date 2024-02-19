namespace RainFallApi.Endpoints.Response;

public class Responses
{
    public RainfallReadingResponse RainfallReadingResponse  { get; set; }
    public ErrorResponse ErrorResponse { get; set; }
}

public class RainfallReadingResponse
{
    public List<RainfallReading> Readings { get; set; }
}

public class RainfallReading
{
    public DateTime DateMeasured { get; set; }
    public decimal AmountMeasured { get; set; }
}

public class Error
{
    public string Message { get; set; }
    public List<ErrorDetail> Detail { get; set; } = new();
}

public class ErrorDetail
{
    public string PropertyName { get; set; }
    public string Message { get; set; }
}

public class ErrorResponse
{
    public string Message { get; set; }
}