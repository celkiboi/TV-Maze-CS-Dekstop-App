using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVLibrary.TV;

public record class Person
(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("country")] Country Country,
    [property: JsonPropertyName("birthday")] DateOnly Birthday,
    [property: JsonPropertyName("gender")] string Gender,
    [property: JsonPropertyName("image")] Image Image
)
{
    // some actors aren't dead yet
    // due to such thing, the API returns null for "deathday"
    // as the .NET DateOnly is a value type, we have to use the nullable DateOnly? type
    // this project aims to reduce null usage, replacing null values with default values
    // as a result a tuple with a bool is used to give info on actors life status
    // this way the user is forced to check for "nulability" (he has to deconstruct a tuple)
    // even if he doesn't do that, the program won't crash and he will be represented with DateOnly.Max value
    // this method is better than just returning DateOnly.Max because in that instance,
    // the user does not know he has to check for DateOnly.Max
    // forced to add another constructor due to record type constraint
    // if a contructor without deathday is called, a person that is still alive will be created
    // deathday will NOT be included in ToString() output!!!

    [JsonPropertyName("deathday")]
    readonly DateOnly? deathday;

    public (bool isDead, DateOnly deathDate) Deathday
    {
        get 
        {
            if (deathday == null) 
            {
                return (false, DateOnly.MaxValue);
            }
            return (true, (DateOnly)deathday);
        }
    }

    public Person(int id, string url, string name, Country country, DateOnly birthday, DateOnly? deathday,
        string gender, Image image) 
        : this(id, url, name, country, birthday, gender, image)
    {
        this.deathday = deathday;
    }
}
