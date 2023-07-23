using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVLibrary.TV;

public record class Episode
(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("season")] int Season,
    [property: JsonPropertyName("number")] int Number,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("airdate")] DateOnly AirDate,
    [property: JsonPropertyName("runtime")] int Runtime,
    [property: JsonPropertyName("image")] Image Image
)
{
    
}
