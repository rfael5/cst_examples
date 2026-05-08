using System.Text.Json;
using System.Text.Json.Nodes;

public static  class JsonExamples
{
    public static void TestSerializer()
    {
        var model = new SimpleData
        {
            Id = 42,
            Names = new[] { "Bell", "Stacey", "her", "Jane" },
            Location = new NestedData
            {
                LocationName = "London",
                Latitude = 51.503209,
                Longitude = -0.119145
            },
            Map = new Dictionary<string, int>
            {
                { "Answer", 42 },
                { "FirstPrime", 2 }
            }
        };
        string json = JsonSerializer.Serialize(
        model,
        new JsonSerializerOptions (JsonSerializerDefaults.Web){ WriteIndented = true,  });
        
        JsonNode rootNode = JsonNode.Parse(json)!;
        JsonNode mapNode = rootNode["map"]!;
        rootNode["iceCream"] = 99;

        Console.WriteLine(rootNode);
        // using(JsonDocument document = JsonDocument.Parse(json))
        // {
        //     // foreach(JsonProperty property in document.RootElement.EnumerateObject())
        //     // {
        //     //     Console.WriteLine($"{property.Name}: {property.Value} ({property.Value.ValueKind})");
        //     // }
        //     var root = document.RootElement;
        //     if(root.TryGetProperty("location", out JsonElement locationElement))
        //     {
        //         string locationName = locationElement.GetProperty("locationName").GetString()!;
        //         double latitude = locationElement.GetProperty("latitude").GetDouble();
        //         double longitude = locationElement.GetProperty("longitude").GetDouble();
        //         Console.WriteLine($"Location: {locationName}: {latitude}, {longitude}");

        //     }
        // }

    }
}



public class SimpleData
{
public int Id { get; set; }
public IList<string>? Names { get; set; }
public NestedData? Location { get; set; }
public IDictionary<string, int>? Map { get; set; }
}
public class NestedData
{
public string? LocationName { get; set; }
public double Latitude { get; set; }
public double Longitude { get; set; }
}

