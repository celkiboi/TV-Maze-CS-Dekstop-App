using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Database;
using TVLibrary.Serialization;
using TVLibrary.TV;
using TVLibrary.TV.Builders;

namespace TVLibrary.Requests;

public class TVMaze : IRequestDispatcher
{
    static TVMaze? instance;

    readonly IDeserializer deserializer;
    readonly IDatabase database;

    private TVMaze()
    {
        deserializer = new JSONDeserializerAdapter();
        database = new CacheDatabase(new RemoteDatabase(), new TimeSpan(0,0, 30));
    }
    public static TVMaze Instance
    {
        get { return instance ??= new(); }
        private set { instance = value; }
    }

    public IEnumerable<Show> SearchShows(string query)
    {
        query = MakeShowSearchQuery(query);

        string response = database.FetchDataAsync(query).Result;

        IEnumerable<Show>? shows = deserializer.Deserialize<IEnumerable<Show>>(response);
        if (shows is null)
        {
            return Enumerable.Empty<Show>();
        }

        return shows;
    }

    public Show SingleSearchShows(string query)
    {
        query = MakeSingleShowSearchQuery(query);

        string response = database.FetchDataAsync(query).Result;

        Show? show = deserializer.Deserialize<Show>(response);
        if (show is null)
        {
            return ShowDirector.Instance.NullShow;
        }

        return show;
    }
    public Show SearchShowById(int id)
    {
        string query = MakeShowSearchByIdQuery(id);

        string response = database.FetchDataAsync(query).Result;

        Show? show = deserializer.Deserialize<Show?>(response);
        if (show is null)
        {
            return ShowDirector.Instance.NullShow;
        }

        return show;
    }

    static string MakeShowSearchQuery(string query) 
        => @"https://api.tvmaze.com/search/shows?q=" + query;
    static string MakeSingleShowSearchQuery(string query) 
        => @"https://api.tvmaze.com/singlesearch/shows?q=" + query;
    static string MakeShowSearchByIdQuery(int id)
        => @"https://api.tvmaze.com/shows/" + id.ToString();

}
