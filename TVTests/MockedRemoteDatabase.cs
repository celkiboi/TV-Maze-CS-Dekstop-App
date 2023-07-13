using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Database;

namespace TVTests;
// used to mock remote database when testing
// returns an integer as string, it increases by one everytime when triggered. This is used to test cacheing. 

internal class MockedRemoteDatabase : IDatabase
{
    int numberOfTriggers = 0;

    // non issue, this is just a mock
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<string> FetchDataAsync(string url)
    {
        return numberOfTriggers++.ToString();
    }

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
}
