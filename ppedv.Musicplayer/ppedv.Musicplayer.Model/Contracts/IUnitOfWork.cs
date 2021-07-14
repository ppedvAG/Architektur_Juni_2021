namespace ppedv.Musicplayer.Model.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Song> SongsRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        IArtistRepository ArtistRepository { get; }

        void Save();

    }
}
