using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;

namespace ppedv.Musicplayer.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void GetArtistWithMostSongs_no_Artists_in_DB()
        {
            var mock = new Mock<IRepository>();
            var core = new Core(mock.Object);

            var result = core.GetArtistWithMostSongs();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetArtistWithMostSongs_3_Artists_the_second_has_most_songs()
        {
            var core = new Core(new TestRepository());

            var result = core.GetArtistWithMostSongs();

            Assert.AreEqual("A2", result.Name);
        }

        [TestMethod]
        public void GetArtistWithMostSongs_3_Artists_the_second_has_most_songs_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Artist>()).Returns(() =>
            {
                var s1 = new Song() { Title = "S1" };
                var s2 = new Song() { Title = "S2" };
                var s3 = new Song() { Title = "S3" };

                var a1 = new Artist() { Name = "A1" };
                var a2 = new Artist() { Name = "A2" };
                var a3 = new Artist() { Name = "A3" };

                a1.Songs.Add(s1);
                a3.Songs.Add(s1);
                a3.Songs.Add(s3);
                a2.Songs.Add(s1);
                a2.Songs.Add(s2);
                a2.Songs.Add(s3);

                return new[] { a1, a2, a3 };
            });

            var core = new Core(mock.Object);

            var result = core.GetArtistWithMostSongs();

            Assert.AreEqual("A2", result.Name);

            mock.Verify(x => x.Save(), Times.Never);
        }


        [TestMethod]
        public void GetArtistWithMostSongs_2_Artists_some_songs_count_the_older_one_is_result()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Artist>()).Returns(() =>
            {
                var s1 = new Song() { Title = "S1" };
                var s2 = new Song() { Title = "S2" };

                var a1 = new Artist() { Name = "A1", BirthDate = DateTime.Now.AddYears(-40) };
                var a2 = new Artist() { Name = "A2", BirthDate = DateTime.Now.AddYears(-50) };

                a1.Songs.Add(s1);
                a1.Songs.Add(s2);
                a2.Songs.Add(s1);
                a2.Songs.Add(s2);

                return new[] { a1, a2 };
            });

            var core = new Core(mock.Object);

            var result = core.GetArtistWithMostSongs();

            Assert.AreEqual("A2", result.Name);

        }
    }
}
