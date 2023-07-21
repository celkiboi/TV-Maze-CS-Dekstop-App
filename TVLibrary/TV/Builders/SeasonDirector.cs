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
    Season? sampleSeason;

    private SeasonDirector() { }

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


}
