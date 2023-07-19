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
        
        return shows ?? Enumerable.Empty<Show>();
    }

    public Show SingleSearchShows(string query)
    {
        query = MakeSingleShowSearchQuery(query);

        string response = database.FetchDataAsync(query).Result;

        Show? show = deserializer.Deserialize<Show>(response);

        return show ?? ShowDirector.Instance.NullShow;
    }
    public Show SearchShowById(int id)
    {
        string query = MakeShowSearchByIdQuery(id);

        string response = database.FetchDataAsync(query).Result;

        Show? show = deserializer.Deserialize<Show?>(response);
        
        return show ?? ShowDirector.Instance.NullShow;
    }
    public IEnumerable<Season> FetchSeasons(int showId)
    {
        string query = SeasonsFetchByShowIdQuery(showId);

        string response = database.FetchDataAsync(query).Result;

        IEnumerable<Season>? seasons = deserializer.Deserialize<IEnumerable<Season>>(response);
        
        return seasons ?? Enumerable.Empty<Season>();
    }

    public IEnumerable<Season> FetchSeasons(Show show)
    {
        return FetchSeasons(show.ID);
    }

    public IEnumerable<Episode> FetchEpisodes(Show show)
    {
        string query = EpisodesFetchByShowQuery(show);

        string response = database.FetchDataAsync(query).Result;

        IEnumerable<Episode>? episodes = deserializer.Deserialize<IEnumerable<Episode>>(response);
        
        return episodes ?? Enumerable.Empty<Episode>();
    }

    public IEnumerable<Episode> FetchEpisodes(Season season)
    {
        string query = EpisodesFetchBySeasonQuery(season);

        string response = database.FetchDataAsync(query).Result;

        IEnumerable<Episode>? episodes = deserializer.Deserialize<IEnumerable<Episode>>(response);

        return episodes ?? Enumerable.Empty<Episode>();

    }

    static string MakeShowSearchQuery(string query) 
        => @"https://api.tvmaze.com/search/shows?q=" + query;
    static string MakeSingleShowSearchQuery(string query) 
        => @"https://api.tvmaze.com/singlesearch/shows?q=" + query;
    static string MakeShowSearchByIdQuery(int id)
        => @"https://api.tvmaze.com/shows/" + id.ToString();
    static string SeasonsFetchByShowIdQuery(int id)
        => $"https://api.tvmaze.com/shows/{id}/seasons";
    static string EpisodesFetchBySeasonQuery(Season season)
        => $"https://api.tvmaze.com/seasons/{season.Id}/episodes";
    static string EpisodesFetchByShowQuery(Show show)
        => $"https://api.tvmaze.com/seasons/{show.ID}/episodes";
}
