using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.TV;

namespace TVLibrary.Requests;

public interface IRequestDispatcher
{
    IEnumerable<Show> SearchShows(string showName);

    Show SingleSearchShows(string showName);

    Show SearchShowById(int id);

    IEnumerable<Season> FetchSeasons(int showId);

    IEnumerable<Season> FetchSeasons(Show show);

    IEnumerable<Episode> FetchEpisodes(Show show);

    IEnumerable<Episode> FetchEpisodes(Season season);
}
