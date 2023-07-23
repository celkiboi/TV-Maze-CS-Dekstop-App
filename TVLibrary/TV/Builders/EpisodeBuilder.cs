using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.TV.Builders;

public class EpisodeBuilder
{
    int id;
    string? url;
    string? name;
    int season;
    int number;
    string? type;
    DateOnly airDate;
    int runtime;
    Image? image;

    public EpisodeBuilder BuildId(int id)
    {
        this.id = id;
        return this;
    }

    public EpisodeBuilder BuildUrl(string url)
    {
        this.url = url;
        return this;
    }

    public EpisodeBuilder BuildName(string name)
    {
        this.name = name; return this;
    }

    public EpisodeBuilder BuildSeason(int season)
    {
        this.season = season;
        return this;
    }

    public EpisodeBuilder BuildNumber(int number)
    {
        this.number = number; 
        return this;
    }

    public EpisodeBuilder BuildType(string type)
    {
        this.type = type; 
        return this;
    }

    public EpisodeBuilder BuildAirDate(DateOnly airDate)
    {
        this.airDate = airDate;
        return this;
    }

    public EpisodeBuilder BuildRuntime(int runtime)
    {
        this.runtime = runtime;
        return this;
    }

    public EpisodeBuilder BuildImage(Image image)
    {
        this.image = image; 
        return this;
    }

    public Episode Build()
    {
        if (HasZeroNullParameters())
            return new(id, url!, name!, season, number, type!, airDate, runtime, image!);
        else
            throw new InvalidOperationException("Attempted to build, while there was a null value!");
    }

    bool HasZeroNullParameters()
    {
        return (url != null) &&
            (name != null) &&
            (type != null) &&
            (image != null);
    }
}
