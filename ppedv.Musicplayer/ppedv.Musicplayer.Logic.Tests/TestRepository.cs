using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.Musicplayer.Logic.Tests
{
    class TestUnitOfWork : IUnitOfWork
    {
        public IRepository<Song> SongsRepository => throw new NotImplementedException();

        public IRepository<Genre> GenreRepository => throw new NotImplementedException();

        //public IRepository<Artist> ArtistRepository => new TestRepository<Artist>();
        public IRepository<Artist> ArtistRepository => new TestRepository();

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    class TestRepository : IRepository<Artist>
    {
        public void Add(Artist item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Artist item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Artist> Query()
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

            return new[] { a1, a2, a3 }.AsQueryable();

        }

        public Artist GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Artist item)
        {
            throw new NotImplementedException();
        }
    }
}
