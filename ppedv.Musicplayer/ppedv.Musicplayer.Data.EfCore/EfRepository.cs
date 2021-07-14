using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Musicplayer.Data.EfCore
{
    public class EfRepository : IRepository
    {
        EfContext context = new EfContext();

        public void Add<T>(T item) where T : Entity
        {
            //if (typeof(T) == typeof(Song))
            //    context.Songs.Add(item as Song);
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T item) where T : Entity
        {
             context.Set<T>().Update(item);
        }
    }
}
