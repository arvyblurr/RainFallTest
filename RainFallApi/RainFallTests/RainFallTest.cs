using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RainFallApi.ApiProvider;


namespace RainFallTests;

public class RainFallTest
{
    private string ProviderURL = "https://environment.data.gov.uk/";


    [Fact]
    public async void TestApiAvailability()
    {
        //Setup
        var result = await ProviderURL.GetAsync();

        //Assert
        Assert.Equal(result.StatusCode, 200);
    }

    [Fact]
    public async void TestApiResponseParser()
    {
        //Setup
        List<RawResponseModel> result;
        // read JSON directly from a file
        using (StreamReader file = File.OpenText("ApiResponse.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject response = (JObject)JToken.ReadFrom(reader);

            result = response["items"]!.ToObject<List<RawResponseModel>>()!;
        }

        //Assert
        Assert.NotNull(result[0].Id);
        Assert.NotNull(result[0].DateTime);
        Assert.NotNull(result[0].Measure);
        Assert.NotNull(result[0].Value);
    }

    [Fact]
    public async void TestApiResponseEmptyResult()
    {

        //Setup
        List<RawResponseModel> result;

        // read JSON directly from a file
        using (StreamReader file = File.OpenText("ApiEmptyResponse.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject response = (JObject)JToken.ReadFrom(reader);

            result = response["items"]!.ToObject<List<RawResponseModel>>()!;
        }

        //Assert
        Assert.Empty(result);
    }
}