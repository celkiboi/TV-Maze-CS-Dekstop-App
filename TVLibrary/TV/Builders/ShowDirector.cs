using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.TV.Builders;

public class ShowDirector
{
    static ShowDirector? instance;
    Show? nullShow;
    Show? sampleShow;

    private ShowDirector() { }

    public static ShowDirector Instance
    {
        get { return instance ??= new(); }
        private set { instance = value; }
    }

    public Show NullShow => nullShow ??= BuildNullShow();

    static Show BuildNullShow()
    {
        ShowBuilder builder = new();
        return builder.BuildId(0)
            .BuildURL(string.Empty)
            .BuildName(string.Empty)
            .BuildGenres(Array.Empty<string>())
            .BuildStatus(string.Empty)
            .BuildRuntime(0)
            .BuildAverageRuntime(0)
            .BuildPremiere(DateOnly.MinValue)
            .BuildEnd(DateOnly.MaxValue)
            .BuildOffciailSite(string.Empty)
            .BuildImage(Image.NullImage)
            .Build();
    }

    public Show SampleShow => sampleShow ??= BuildSampleShow();

    static Show BuildSampleShow()
    {
        ShowBuilder builder = new();
        return builder.BuildId(1)
            .BuildURL("https://www.tvmaze.com/shows/1/under-the-dome")
            .BuildName("Under the Dome")
            .BuildGenres(new string[] {"Drama", "Science-Fiction", "Thriller"})
            .BuildStatus("Ended")
            .BuildRuntime(60)
            .BuildAverageRuntime(60)
            .BuildPremiere(new DateOnly(2013, 06, 24))
            .BuildEnd(new DateOnly(2015, 09, 10))
            .BuildOffciailSite("http://www.cbs.com/shows/under-the-dome/")
            .BuildImage(new Image("https://static.tvmaze.com/uploads/images/medium_portrait/81/202627.jpg", 
            "https://static.tvmaze.com/uploads/images/original_untouched/81/202627.jpg"))
            .Build();
    }
}
