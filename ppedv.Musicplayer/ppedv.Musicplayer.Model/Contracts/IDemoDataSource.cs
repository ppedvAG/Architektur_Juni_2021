using System.Collections.Generic;

namespace ppedv.Musicplayer.Model.Contracts
{
    public interface IDemoDataSource
    {
        IEnumerable<Song> GetDemoSongsWithGenreAndArtists();

    }
}
