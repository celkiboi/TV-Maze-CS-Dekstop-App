﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Database;
using TVLibrary.Serialization;
using TVLibrary.TV;

namespace TVLibrary.Requests;

public class TVMaze : IRequestDispatcher
{
    readonly IDeserializer deserializer;
    readonly IDatabase database;

    private TVMaze()
    {
        deserializer = new JSONDeserializerAdapter();
        database = new CacheDatabase(new RemoteDatabase(), new TimeSpan(0,0, 30));
    }

    public IEnumerable<Show> SearchShows(string query)
    {
        query = MakeShowSearchQuery(query);

        string? response = database.FetchDataAsync(query).Result;
        if (response is null) 
        {
            return Enumerable.Empty<Show>();
        }

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

        string? response = database.FetchDataAsync(query).Result;
        if (response is null)
        {
            return Show.NullObject;
        }

        Show? show = deserializer.Deserialize<Show>(response);
        if (show is null)
        {
            return Show.NullObject;
        }

        return show;
    }

    static string MakeShowSearchQuery(string query) 
        => @"https://api.tvmaze.com/search/shows?q=" + query;
    static string MakeSingleShowSearchQuery(string query) 
        => @"https://api.tvmaze.com/singlesearch/shows?q=" + query;

}