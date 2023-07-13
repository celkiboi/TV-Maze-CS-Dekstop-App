using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVLibrary.TV;

public record class Image
(
     [property: JsonPropertyName("medium")] string MediumSizeLink,
     [property: JsonPropertyName("original")] string OriginalSizeLink
)
{ }
