namespace RainFallApi.Endpoints.Responses;



public class responses
{
    public rainfallReadingResponse rainfallReadingResponse  { get; set; }
    public errorResponse errorResponse { get; set; }
}

public class rainfallReadingResponse
{
    public List<rainfallReading> Readings { get; set; }
}

public class rainfallReading
{
    public DateTime DateMeasured { get; set; }
    public decimal AmountMeasured { get; set; }
}

public class error
{
    public string Message { get; set; }
    public List<errorDetail> Detail { get; set; } = new();
}

public class errorDetail
{
    public string PropertyName { get; set; }
    public string Message { get; set; }
}

public class errorResponse
{
    public string Message { get; set; }
}