using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ppedv.Musicplayer.Device.Beeper5000
{
    public class Beeper : ISoundDevice
    {
        public void PlaySong(IEnumerable<Tuple<int, int, int>> song)
        {
            foreach (var item in song)
            {
                PlaySound(item.Item1, item.Item2);
                Thread.Sleep(item.Item3);
            }
        }

        public void PlaySound(int freq, int duration)
        {
            Console.Beep(freq, duration);
        }
    }
}
