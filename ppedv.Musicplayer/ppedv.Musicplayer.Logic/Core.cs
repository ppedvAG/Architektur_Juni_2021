using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System.Linq;

namespace ppedv.Musicplayer.Logic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public Core() : this(new Data.EfCore.EfRepository())
        { }


        public Artist GetArtistWithMostSongs()
        {
            return Repository.GetAll<Artist>().OrderByDescending(x => x.Songs.Count).ThenBy(x => x.BirthDate).FirstOrDefault();
        }

    }
}
