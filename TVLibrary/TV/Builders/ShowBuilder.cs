using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.TV.Builders;

public class ShowBuilder : IDisposable
{
    int id;
    string? url;
    string? name;
    string[]? genres;
    string? status;
    int runtime;
    int averageRuntime;
    DateOnly premiere;
    DateOnly end;
    string? officialSite;
    Image? image;

    public ShowBuilder BuildId(int id)
    {
        this.id = id;
        return this;
    }

    public ShowBuilder BuildURL(string url)
    {
        this.url = url;
        return this;
    }

    public ShowBuilder BuildName(string name)
    {
        this.name = name;
        return this;
    }

    public ShowBuilder BuildGenres(string[] genres) 
    {
        this.genres = genres;
        return this;
    }

    public ShowBuilder BuildStatus(string status)
    {
        this.status = status;
        return this;
    }

    public ShowBuilder BuildRuntime(int runtime)
    {
        this.runtime = runtime;
        return this;
    }

    public ShowBuilder BuildAverageRuntime(int averageRuntime)
    {
        this.averageRuntime = averageRuntime;
        return this;
    }

    public ShowBuilder BuildPremiere(DateOnly premiere)
    {
        this.premiere = premiere;
        return this;
    }

    public ShowBuilder BuildEnd(DateOnly end)
    {
        this.end = end;
        return this;
    }

    public ShowBuilder BuildOffciailSite(string officialSize)
    {
        this.officialSite = officialSize;
        return this;
    }

    public ShowBuilder BuildImage(Image image)
    {
        this.image = image;
        return this;
    }

    public Show Build()
    {
        if (NoMemberIsNull())
            return new Show(id, url!, name!, genres!, status!, runtime, averageRuntime, premiere, end, officialSite!, image!);
        else
            throw new InvalidOperationException("Attempted to build, while there was a null value!");
    }

    bool NoMemberIsNull()
    {
        return (url != null) &&
            (name != null) &&
            (genres != null) &&
            (status != null) &&
            (officialSite != null) &&
            (image != null);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
