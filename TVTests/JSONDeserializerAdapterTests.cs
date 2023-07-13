using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Serialization;
using TVLibrary.TV;

namespace TVTests;

[TestFixture]
internal class JSONDeserializerAdapterTests
{
    [Test]
    public void TestDeserialization()
    {
        IDeserializer deserializer = new JSONDeserializerAdapter();
        string expected = "Show { ID = 1, URL = https://www.tvmaze.com/shows/1/under-the-dome, Name = Under the Dome, Genres = , Status = Ended, Runtime = 60, AverageRuntime = 60, Premiere = 24-Jun-13, End = 10-Sep-15, OfficialSite = http://www.cbs.com/shows/under-the-dome/, Image = Image { MediumSizeLink = https://static.tvmaze.com/uploads/images/medium_portrait/81/202627.jpg, OriginalSizeLink = https://static.tvmaze.com/uploads/images/original_untouched/81/202627.jpg } }";
        string stream;
        using StreamReader streamReader = new("TestShowJSON.json");
        {
            stream = streamReader.ReadToEnd();
        }

        string actual = deserializer.Deserialize<Show>(stream)!.ToString();

        Assert.That(expected, Is.EqualTo(actual));
    }
}
