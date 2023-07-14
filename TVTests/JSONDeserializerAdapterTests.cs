using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Serialization;
using TVLibrary.TV;
using TVLibrary.TV.Builders;

namespace TVTests;

[TestFixture]
internal class JSONDeserializerAdapterTests
{
    [Test]
    public void TestDeserialization()
    {
        IDeserializer deserializer = new JSONDeserializerAdapter();
        string expected = ShowDirector.Instance.SampleShow.ToString();
        string stream;
        using StreamReader streamReader = new("TestShowJSON.json");
        {
            stream = streamReader.ReadToEnd();
        }

        string actual = deserializer.Deserialize<Show>(stream)!.ToString();

        Assert.That(expected, Is.EqualTo(actual));
    }
}
