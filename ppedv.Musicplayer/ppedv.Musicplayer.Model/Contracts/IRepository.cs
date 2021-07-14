using System.Linq;

namespace ppedv.Musicplayer.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query();
        T GetById(int id);
        void Add(T item);
        void Delete(T item);
        void Update(T item);

    }

}
