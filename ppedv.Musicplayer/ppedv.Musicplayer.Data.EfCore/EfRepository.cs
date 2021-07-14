using ppedv.Musicplayer.Model;
using ppedv.Musicplayer.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.Musicplayer.Data.EfCore
{


    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected EfContext context = null;

        public EfRepository(EfContext context)
        {
            this.context = context;
        }

        public void Add(T item)
        {
            //if (typeof(T) == typeof(Song))
            //    context.Songs.Add(item as Song);
            context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            context.Set<T>().Update(item);
        }
    }
}
