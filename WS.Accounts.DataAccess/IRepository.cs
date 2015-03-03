using System.Linq;

namespace WS.Accounts.DataAccess
{
    public interface IRepository<T> : IQueryable<T>
    {
        void Add(T item);

        void Update(T item);

        void Delete(T item);

        void Submit();
    }
}