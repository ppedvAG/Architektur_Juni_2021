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

        [TestMethod]
        public void Can_CRUD_Artist()
        {
            var art = new Artist() { Name = "Prince" };
            string newName = "The Artist formaly known as Prince";

            using (var con = new EfContext())
            {
                //CREATE
                con.Artists.Add(art);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //READ
                var loaded = con.Artists.Find(art.Id);
                loaded.Should().NotBeNull();

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check UPDATE
                var loaded = con.Artists.Find(art.Id);
                loaded.Name.Should().Be(newName);

                //DELETE
                con.Artists.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check DELETE
                var loaded = con.Artists.Find(art.Id);
                loaded.Should().BeNull();
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
