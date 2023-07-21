using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.TV.Builders;

public class SeasonBuilder : IDisposable
{
    int id;
    string? url;
    int number;
    string? name;
    int episodeOrder;
    DateOnly premiere;
    DateOnly end;
    Network? network;
    Image? image;

    public SeasonBuilder BuildId(int id)
    {
        this.id = id;
        return this;
    }

    public SeasonBuilder BuildURL(string url) 
    {
        this.url = url;
        return this;
    }

    public SeasonBuilder BuildNumber(int number) 
    {
        this.number = number;
        return this;
    }

    public SeasonBuilder BuildName(string name) 
    {
        this.name = name;
        return this;
    }

    public SeasonBuilder BuildEpisodeOrder(int episodeOrder)
    {
        this.episodeOrder = episodeOrder;
        return this;
    }

    public SeasonBuilder BuildPremiere(DateOnly premiere)
    {
        this.premiere = premiere;
        return this;
    }

    public SeasonBuilder BuildEnd(DateOnly end) 
    {
        this.end = end;
        return this;
    }

    public SeasonBuilder BuildNetwork(Network network)
    {
        this.network = network;
        return this;
    }

    public SeasonBuilder BuildImage(Image image) 
    {
        this.image = image;
        return this;
    }

    public Season Build()
    {
        if (HasZeroNullParameters())
            return new Season(id, url!, number, name!, episodeOrder, premiere, end, network!, image!);
        else 
            throw new InvalidOperationException("Attempted to build, while there was a null value!");
    }

    bool HasZeroNullParameters()
    {
        return ((url != null) &&
            (name != null) &&
            (network != null) &&
            (image != null));   
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
