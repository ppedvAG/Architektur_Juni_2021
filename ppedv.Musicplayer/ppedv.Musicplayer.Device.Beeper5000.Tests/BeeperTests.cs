using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ppedv.Musicplayer.Device.Beeper5000.Tests
{
    [TestClass]
    public class BeeperTests
    {
        [TestMethod]
        public void Beeper_can_beep()
        {
            var beeper = new Beeper();

            beeper.PlaySound(250, 400);
        }

        [TestMethod]
        public void Beeper_can_play_tetris()
        {
            var song = new List<Tuple<int, int, int>>();
            song.Add(new Tuple<int, int, int>(1320, 500, 0));
            song.Add(new Tuple<int, int, int>(990, 250, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(1188, 250, 0));
            song.Add(new Tuple<int, int, int>(1320, 125, 0));
            song.Add(new Tuple<int, int, int>(1188, 125, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(990, 250, 0));
            song.Add(new Tuple<int, int, int>(880, 500, 0));
            song.Add(new Tuple<int, int, int>(880, 250, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(1320, 500, 0));
            song.Add(new Tuple<int, int, int>(1188, 250, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(990, 750, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(1188, 500, 0));
            song.Add(new Tuple<int, int, int>(1320, 500, 0));
            song.Add(new Tuple<int, int, int>(1056, 500, 0));
            song.Add(new Tuple<int, int, int>(880, 500, 0));
            song.Add(new Tuple<int, int, int>(880, 500, 250));
            song.Add(new Tuple<int, int, int>(1188, 500, 0));
            song.Add(new Tuple<int, int, int>(1408, 250, 0));
            song.Add(new Tuple<int, int, int>(1760, 500, 0));
            song.Add(new Tuple<int, int, int>(1584, 250, 0));
            song.Add(new Tuple<int, int, int>(1408, 250, 0));
            song.Add(new Tuple<int, int, int>(1320, 750, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(1320, 500, 0));
            song.Add(new Tuple<int, int, int>(1188, 250, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(990, 500, 0));
            song.Add(new Tuple<int, int, int>(990, 250, 0));
            song.Add(new Tuple<int, int, int>(1056, 250, 0));
            song.Add(new Tuple<int, int, int>(1188, 500, 0));
            song.Add(new Tuple<int, int, int>(1320, 500, 0));
            song.Add(new Tuple<int, int, int>(1056, 500, 0));
            song.Add(new Tuple<int, int, int>(880, 500, 0));
            song.Add(new Tuple<int, int, int>(880, 500, 0));

            var beeper = new Beeper();

            beeper.PlaySong(song);
        }
    }
}
