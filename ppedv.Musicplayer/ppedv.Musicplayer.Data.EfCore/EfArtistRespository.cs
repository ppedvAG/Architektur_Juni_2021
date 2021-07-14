using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Musicplayer.Data.EfCore
{
    public class EfArtistRespository : EfRepository<Artist>, IArtistRepository
    {
        public EfArtistRespository(EfContext context) : base(context)
        { }

        public IEnumerable<Artist> GetAllFromCity(string city)
        {
            return context.Artists.Where(x => x.City.ToLower() == city.ToLower()).ToList();
        }
    }
}
