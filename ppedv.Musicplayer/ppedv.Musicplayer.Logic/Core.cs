using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System.Linq;

namespace ppedv.Musicplayer.Logic
{
    public class Core
    {
        public IRepository Repository { get; }
        public ISoundDevice SoundDevice { get; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public Core(IRepository repository, ISoundDevice soundDevice) : this(repository)
        {
            SoundDevice = soundDevice;
            soundDevice.PlaySound(300, 200);
            soundDevice.PlaySound(440, 200);
        }

        public Artist GetArtistWithMostSongs()
        {
            return Repository.GetAll<Artist>().OrderByDescending(x => x.Songs.Count).ThenBy(x => x.BirthDate).FirstOrDefault();
        }

    }
}
