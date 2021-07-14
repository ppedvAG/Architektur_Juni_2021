using System.Collections.Generic;

namespace ppedv.Musicplayer.Model.Contracts
{
    public interface IArtistRepository : IRepository<Artist>
    {
        IEnumerable<Artist> GetAllFromCity(string city);
    }
}
