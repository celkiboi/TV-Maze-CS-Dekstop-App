using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVLibrary.TV;

public record class Network
(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("country")] Country Country,
    [property: JsonPropertyName("officialSite")] string OfficialSite
)
{
    public static Network NullNetwork { get; } = new(0, string.Empty, Country.NullCountry, string.Empty);
}
