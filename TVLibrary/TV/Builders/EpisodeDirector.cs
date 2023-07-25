using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.TV.Builders;

public class EpisodeDirector
{
    static EpisodeDirector? instance;
    Episode? nullEpisode;
    Episode? sampleEpisode;

    private EpisodeDirector() { }

    public static EpisodeDirector Instance
    {
        get { return instance ??= new(); }
        set { instance = value; }
    }

    public Episode NullEpisode => nullEpisode ??= BuildNullEpisode();

    static Episode BuildNullEpisode()
    {
        EpisodeBuilder episodeBuilder = new();
        return episodeBuilder
            .BuildId(0)
            .BuildUrl(string.Empty)
            .BuildName(string.Empty)
            .BuildSeason(0)
            .BuildNumber(0)
            .BuildType(string.Empty)
            .BuildAirDate(DateOnly.MinValue)
            .BuildRuntime(0)
            .BuildImage(Image.NullImage)
            .Build();
    }

    public Episode SampleEpisode => sampleEpisode ??= BuildSampleEpisode();

    static Episode BuildSampleEpisode()
    {
        EpisodeBuilder episodeBuilder = new();
        return episodeBuilder
            .BuildId(1)
            .BuildUrl("https://www.tvmaze.com/episodes/1/under-the-dome-1x01-pilot")
            .BuildName("Pilot")
            .BuildSeason(1)
            .BuildNumber(1)
            .BuildType("regular")
            .BuildAirDate(new DateOnly(13, 6, 24))
            .BuildRuntime(60)
            .BuildImage(new Image(
                "https://static.tvmaze.com/uploads/images/medium_landscape/1/4388.jpg",
                "https://static.tvmaze.com/uploads/images/original_untouched/1/4388.jpg"))
            .Build();
    }
}
