using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Database;
using static System.Net.WebRequestMethods;

namespace TVTests;

[TestFixture]
internal class RemoteDatabaseTests
{
    [Test]
    public void FetchDataAsync_Test()
    {
        RemoteDatabase remoteDatabase = new();
        const string url = "https://api.tvmaze.com/shows/1";
        string expected;
        using StreamReader streamReader = new(@"TVShowFetchDataAsyncTestJSON.json");
        {
            expected = streamReader.ReadToEnd();
        }

        string actual = remoteDatabase.FetchDataAsync(url).Result;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
