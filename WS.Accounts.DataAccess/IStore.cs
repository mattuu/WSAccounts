using System.Collections.Generic;

namespace WS.Accounts.DataAccess
{
    public interface IStore<T>
    {
        void Save(T item);

        T Get(int id);

        IEnumerable<T> GetAll();
    }
}