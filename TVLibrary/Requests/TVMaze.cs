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

    T GetData<T>(string query, T returnsWhenNull)
    {
        string response = database.FetchDataAsync(query).Result;

        T? data = deserializer.Deserialize<T>(response);

        return data ?? returnsWhenNull;
    }

    public IEnumerable<Show> SearchShows(string showName)
    {
        string query = MakeShowSearchQuery(showName);

        return GetData(query, Enumerable.Empty<Show>());
    }

    public Show SingleSearchShows(string showName)
    {
        string query = MakeSingleShowSearchQuery(showName);

        return GetData(query, ShowDirector.Instance.NullShow);
    }
    public Show SearchShowById(int id)
    {
        string query = MakeShowSearchByIdQuery(id);

        return GetData(query, ShowDirector.Instance.NullShow);
    }
    public IEnumerable<Season> FetchSeasons(int showId)
    {
        string query = SeasonsFetchByShowIdQuery(showId);

        return GetData(query, Enumerable.Empty<Season>());
    }

    public IEnumerable<Season> FetchSeasons(Show show)
    {
        return FetchSeasons(show.ID);
    }

    public IEnumerable<Episode> FetchEpisodes(Show show)
    {
        string query = EpisodesFetchByShowQuery(show);

        return GetData(query, Enumerable.Empty<Episode>());
    }

    public IEnumerable<Episode> FetchEpisodes(Season season)
    {
        string query = EpisodesFetchBySeasonQuery(season);

        return GetData(query, Enumerable.Empty<Episode>());
    }

    static string MakeShowSearchQuery(string showName) 
        => @"https://api.tvmaze.com/search/shows?q=" + showName;
    static string MakeSingleShowSearchQuery(string showName) 
        => @"https://api.tvmaze.com/singlesearch/shows?q=" + showName;
    static string MakeShowSearchByIdQuery(int id)
        => @"https://api.tvmaze.com/shows/" + id.ToString();
    static string SeasonsFetchByShowIdQuery(int id)
        => $"https://api.tvmaze.com/shows/{id}/seasons";
    static string EpisodesFetchBySeasonQuery(Season season)
        => $"https://api.tvmaze.com/seasons/{season.Id}/episodes";
    static string EpisodesFetchByShowQuery(Show show)
        => $"https://api.tvmaze.com/seasons/{show.ID}/episodes";
}
