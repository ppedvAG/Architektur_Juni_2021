using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System.Linq;

namespace ppedv.Musicplayer.Logic
{
    public class Core
    {
        public IUnitOfWork UnitOfWork { get; }
        public ISoundDevice SoundDevice { get; }

        public Core(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Core(IUnitOfWork unitOfWork, ISoundDevice soundDevice) : this(unitOfWork)
        {
            SoundDevice = soundDevice;
            soundDevice.PlaySound(300, 200);
            soundDevice.PlaySound(440, 200);
        }

        public Artist GetArtistWithMostSongs()
        {
            return UnitOfWork.ArtistRepository.Query().OrderByDescending(x => x.Songs.Count).ThenBy(x => x.BirthDate).FirstOrDefault();
        }

    }
}
