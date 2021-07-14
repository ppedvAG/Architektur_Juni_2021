using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;

namespace ppedv.Musicplayer.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext context = new EfContext();
        public IRepository<Song> SongsRepository => new EfRepository<Song>(context);

        public IRepository<Genre> GenreRepository => new EfRepository<Genre>(context);

        public IRepository<Artist> ArtistRepository => new EfRepository<Artist>(context);

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
