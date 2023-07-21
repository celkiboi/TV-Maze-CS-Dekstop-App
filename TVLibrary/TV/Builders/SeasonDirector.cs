using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.TV.Builders;

public class SeasonDirector
{
    static SeasonDirector? instance;
    Season? nullSeason;
    IEnumerable<Season>? sampleSeasons;

    private SeasonDirector() { }

    public static SeasonDirector Instance
    {
        get { return instance ??= new(); }
        set { instance = value; }
    }

    public Season NullSeason => nullSeason ??= BuildNullSeason();

    static Season BuildNullSeason()
    {
        SeasonBuilder seasonBuilder = new();
        return seasonBuilder.BuildId(0)
            .BuildURL(string.Empty)
            .BuildNumber(0)
            .BuildName(string.Empty)
            .BuildEpisodeOrder(0)
            .BuildPremiere(DateOnly.MinValue)
            .BuildEnd(DateOnly.MaxValue)
            .BuildNetwork(Network.NullNetwork)
            .BuildImage(Image.NullImage)
            .Build();
    }

    public IEnumerable<Season> SampleSeasons => sampleSeasons ??= BuildSampleSeasons();

    static IEnumerable<Season> BuildSampleSeasons()
    {
        Season[] seasons = new Season[3];
        SeasonBuilder seasonBuilder = new();

        Country country = new("United States", "US", "America/New_York");
        Network network = new(2, "CBS", country, "https://www.cbs.com/");

        seasons[0] = seasonBuilder.BuildId(1)
            .BuildURL("https://www.tvmaze.com/seasons/1/under-the-dome-season-1")
            .BuildNumber(1)
            .BuildName(string.Empty)
            .BuildEpisodeOrder(13)
            .BuildPremiere(new DateOnly(2013, 6, 24))
            .BuildEnd(new DateOnly(2013, 9, 16))
            .BuildNetwork(network)
            .BuildImage(new Image(
                "https://static.tvmaze.com/uploads/images/medium_portrait/24/60941.jpg",
                "https://static.tvmaze.com/uploads/images/original_untouched/24/60941.jpg"))
            .Build();

        seasons[1] = seasonBuilder.BuildId(2)
            .BuildURL("https://www.tvmaze.com/seasons/2/under-the-dome-season-2")
            .BuildNumber(2)
            .BuildName(string.Empty)
            .BuildEpisodeOrder(13)
            .BuildPremiere(new DateOnly(2014,6,30))
            .BuildEnd(new DateOnly(2014, 9, 22))
            .BuildNetwork(network)
            .BuildImage(new Image(
                "https://static.tvmaze.com/uploads/images/medium_portrait/24/60942.jpg",
                "https://static.tvmaze.com/uploads/images/original_untouched/24/60942.jpg"))
            .Build();

        seasons[2] = seasonBuilder.BuildId(6233)
            .BuildURL("https://www.tvmaze.com/seasons/6233/under-the-dome-season-3")
            .BuildNumber(3)
            .BuildName(string.Empty)
            .BuildEpisodeOrder(13)
            .BuildPremiere(new DateOnly(2015,6,25))
            .BuildEnd(new DateOnly(2015,9,10))
            .BuildNetwork(network)
            .BuildImage(new Image(
                "https://static.tvmaze.com/uploads/images/medium_portrait/182/457332.jpg",
                "https://static.tvmaze.com/uploads/images/original_untouched/182/457332.jpg"))
            .Build();

        return seasons;
    }
}
