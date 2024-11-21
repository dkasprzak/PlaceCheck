using Newtonsoft.Json;

namespace PlaceCheck.Infrastructure.GooglePlacesApi.Helpers;

public static class JsonFormatter
{
    public static string FormatJson(string rawJson)
    {
        try
        {
            var parsedJson = JsonConvert.DeserializeObject(rawJson);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
        catch (JsonReaderException)
        {
            return rawJson;
        }
    }
}
