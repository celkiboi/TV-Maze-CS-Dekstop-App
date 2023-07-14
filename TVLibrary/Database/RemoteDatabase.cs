using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.Database;

public class RemoteDatabase : IDatabase
{
    readonly HttpClient client = new();

    public async Task<string> FetchDataAsync(string url)
    {
        string result;

        try
        {
            result = await client.GetStringAsync(url);
        }
        catch
        {
            return string.Empty;
        }

        return result;
    }
}
