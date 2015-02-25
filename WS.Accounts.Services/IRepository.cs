using System.Linq;

namespace WS.Accounts.Services
{
    public interface IRepository<T> : IQueryable<T>
    {
        T Find(params object[] keyValues);

        IQueryable<T> GetAll();

        void Add(T item, bool save = false);

        void Delete(T item, bool save = false);

        void Update(T item, bool save = false);

        void SubmitChanges();

        void RollbackChanges();

        IQueryable<T> Include(string path);
    }
}