using System.Linq;

namespace ppedv.Musicplayer.Model.Contracts
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : Entity;
        T GetById<T>(int id) where T : Entity;
        void Add<T>(T item) where T : Entity;
        void Delete<T>(T item) where T : Entity;
        void Update<T>(T item) where T : Entity;

        void Save();

    }
}
