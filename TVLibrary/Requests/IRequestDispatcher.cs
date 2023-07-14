using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVLibrary.TV;

namespace TVLibrary.Requests;

public interface IRequestDispatcher
{
    IEnumerable<Show> SearchShows(string query);

    Show SingleSearchShows(string query);

    Show SearchShowById(int id);
}
