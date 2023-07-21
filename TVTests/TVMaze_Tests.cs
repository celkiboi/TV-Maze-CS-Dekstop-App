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

    }
}
