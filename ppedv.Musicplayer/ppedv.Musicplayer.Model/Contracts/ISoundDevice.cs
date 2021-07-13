using System;
using System.Collections.Generic;

namespace ppedv.Musicplayer.Model.Contracts
{
    public interface ISoundDevice
    {
        void PlaySound(int freq, int duration);

        void PlaySong(IEnumerable<Tuple<int, int, int>> song);
    }
}
