using ppedv.Musicplayer.Model;
using System;
using System.Linq;

namespace ppedv.Musicplayer.Logic
{
    public class Core
    {

        public Genre GetGenreOfOldestArtists()
        {

            var con = new Data.EfCore.EfContext();

            return con.Genres.FirstOrDefault();
        }

    }
}
