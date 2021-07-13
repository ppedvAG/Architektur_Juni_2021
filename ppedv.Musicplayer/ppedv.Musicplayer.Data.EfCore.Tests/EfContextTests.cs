using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Musicplayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ppedv.Musicplayer.Data.EfCore.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            Assert.IsTrue(con.Database.EnsureCreated());
        }

        [TestMethod]
        public void Can_add_Song_to_DB()
        {
            var song = new Song() { Title = $"Song #{Guid.NewGuid()}" };

            using (var con = new EfContext())
            {
                con.Songs.Add(song);
                con.SaveChanges();
            } //con.Dispose();

            using (var con = new EfContext())
            {
                var loaded = con.Songs.Find(song.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(song.Title, loaded.Title);
            }
        }

        [TestMethod]
        public void Can_add_Genre_AutoFix_FluentAssertions()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));

            var genre = fix.Build<Genre>().Create();

            using (var con = new EfContext())
            {
                con.Genres.Add(genre);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Genres.Find(genre.Id);

                loaded.Should().BeEquivalentTo(genre, o => o.IgnoringCyclicReferences());
            }
        }

    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}
