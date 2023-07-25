using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.Requests;
using TVLibrary.TV;
using TVLibrary.TV.Builders;

namespace TVTests;

[TestFixture]
public class TVMaze_Tests
{
    [Test]
    public void TVMazeTest_SearchShowByID()
    {
        Show expectedShow = ShowDirector.Instance.SampleShow;
        TVMaze tvMaze = TVMaze.Instance;

        Show actualShow = tvMaze.SearchShowById(1);

        string expected = expectedShow.ToString();
        string actual = actualShow.ToString();

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TVMazeTest_SingleSearchShow()
    {
        Show expectedShow = ShowDirector.Instance.SampleShow;
        TVMaze tvMaze = TVMaze.Instance;

        Show actualShow = tvMaze.SingleSearchShows("Under the dome");

        string expected = expectedShow.ToString();
        string actual = actualShow.ToString();

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TVMazeTest_FetchSeasons_ByShowId()
    {
        IEnumerable<Season> expectedSeasons = SeasonDirector.Instance.SampleSeasons;
        TVMaze tvMaze = TVMaze.Instance;
        string expected = "";
        foreach (Season season in expectedSeasons)
        {
            expected += $"{season}, ";
        }

        IEnumerable<Season> actualSeasons = tvMaze.FetchSeasons(1);

        string actual = "";
        foreach (Season season in actualSeasons)
        {
            actual += $"{season}, ";
        }

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TVMazeTest_FetchSeasons_ByShow()
    {
        IEnumerable<Season> expectedSeasons = SeasonDirector.Instance.SampleSeasons;
        TVMaze tvMaze = TVMaze.Instance;
        Show show = ShowDirector.Instance.SampleShow;
        string expected = "";
        foreach (Season season in expectedSeasons)
        {
            expected += $"{season}, ";
        }

        IEnumerable<Season> actualSeasons = tvMaze.FetchSeasons(show);

        string actual = "";
        foreach (Season season in actualSeasons)
        {
            actual += $"{season}, ";
        }

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TVMazeTest_FetchEpisodes_ByShow()
    {
        Episode expectedEpisode = EpisodeDirector.Instance.SampleEpisode;
        TVMaze tVMaze = TVMaze.Instance;
        Show show = ShowDirector.Instance.SampleShow;
        string expected = expectedEpisode.ToString();

        IEnumerable<Episode> episodes = tVMaze.FetchEpisodes(show);
        Episode? actualEpisode = episodes.FirstOrDefault();
        string actual;
        if (actualEpisode is null)
            actual = string.Empty;
        else
            actual = actualEpisode.ToString();

        Assert.That(actual, Is.EqualTo(expected)); 
    }

    [Test]
    public void TVMazeTest_FetchEpisodes_BySeason()
    {
        Episode expectedEpisode = EpisodeDirector.Instance.SampleEpisode;
        TVMaze tVMaze = TVMaze.Instance;
        Season season = SeasonDirector.Instance.SampleSeason;
        string expected = expectedEpisode.ToString();

        IEnumerable<Episode> episodes = tVMaze.FetchEpisodes(season);
        Episode? actualEpisode = episodes.FirstOrDefault();
        string actual;
        if (actualEpisode is null)
            actual = string.Empty;
        else
            actual = actualEpisode.ToString();

        Assert.That(actual, Is.EqualTo(expected));
    }
}
