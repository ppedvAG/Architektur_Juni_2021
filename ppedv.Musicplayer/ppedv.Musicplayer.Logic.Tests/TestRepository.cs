using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Musicplayer.Logic.Tests
{
    class TestRepository : IRepository
    {
        public void Add<T>(T item) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T item) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Artist))
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

                return new[] { a1, a2, a3 }.Cast<T>();
            }

            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item) where T : Model.Entity
        {
            throw new NotImplementedException();
        }
    }
}
