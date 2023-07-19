using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVLibrary.TV;

public record class Season
(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("number")] int Number,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("episodeOrder")] int EpisodeOrder,
    [property: JsonPropertyName("premiereDate")] DateOnly Premiere,
    [property: JsonPropertyName("endDate")] DateOnly End,
    [property: JsonPropertyName("network")] Network Network,
    [property: JsonPropertyName("image")] Image Image
)
{
}
