using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Database;

namespace TVTests;

[TestFixture]
internal class CacheDatabaseTests
{
    [TestCase("00", "sample", "sample")]
    [TestCase("01", "sample", "sample2")]
    public void TestCache_WhenItGetsCached(string expected, string firstURL, string secondURL)
    {
        IDatabase remote = new MockedRemoteDatabase();
        CacheDatabase database = new(remote);

        string actual = database.FetchDataAsync(firstURL).Result + database.FetchDataAsync(secondURL).Result;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
