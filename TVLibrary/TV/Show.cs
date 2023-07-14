using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVLibrary.TV;

public record class Show
(
    [property: JsonPropertyName("id")] int ID,
    [property: JsonPropertyName("url")] string URL,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("genre")] string[] Genres,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("runtime")] int Runtime,
    [property: JsonPropertyName("averageRuntime")] int AverageRuntime,
    [property: JsonPropertyName("premiered")] DateOnly Premiere,
    [property: JsonPropertyName("ended")] DateOnly End,
    [property: JsonPropertyName("officialSite")] string OfficialSite,
    [property: JsonPropertyName("image")] Image Image
)
{
    public static Show NullObject { get; } = new Show(0, "", "", 
        new string[]{""}, "Didn't run", 
        0, 0, DateOnly.MinValue, DateOnly.MaxValue, 
        "", new Image("", ""));
}
