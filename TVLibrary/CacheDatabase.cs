using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary;

public class CacheDatabase : IDatabase
{
    readonly IDatabase remoteDatabase;
    readonly Dictionary<string, (DateTime, string)> localData = new();
    readonly TimeSpan maximumTimeDifference;

    public CacheDatabase(IDatabase remoteDatabase)
        :this(remoteDatabase, new TimeSpan(0,0,30))
    { }

    public CacheDatabase(IDatabase remoteDatabase, TimeSpan maximumTimeDifference) 
    {
        this.remoteDatabase = remoteDatabase;
        this.maximumTimeDifference = maximumTimeDifference;
    }

    public async Task<string> FetchDataAsync(string url)
    {
        if (localData.ContainsKey(url)) 
        {
            if (IsNewEnough(localData[url])) 
            {
                return localData[url].Item2;
            }
            localData.Remove(url);
        }

        await CacheRemoteData(url);
        return localData[url].Item2;
    }

    async Task CacheRemoteData(string url)
    {
        string result = await remoteDatabase.FetchDataAsync(url);
        localData.Add(url, (DateTime.Now, result));
    }

    bool IsNewEnough((DateTime, string) data) 
    {
        return (DateTime.Now - data.Item1) <= maximumTimeDifference;
    }
}
