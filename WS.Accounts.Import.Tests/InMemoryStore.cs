using System;
using System.Collections.Generic;
using System.Linq;
using WS.Accounts.DataAccess;
using WS.Accounts.Entities;

namespace WS.Accounts.Import.Tests
{
    public class InMemoryAccountStore : InMemoryStore<Account>, IAccountStore
    {
        
    }

    public class InMemoryStore<T> : IStore<T>
    {
        private readonly IRepository<T> _repository;

        public InMemoryStore()
        {
            _repository = new InMemoryRepository<T>();
        }

        public void Save(T item)
        {
            var id = GetId(item);
            {
                if (id == 0)
                {
                    _repository.Add(item);
                }
                else
                {
                    _repository.Update(item);
                }
            }
        }

        public T Get(int id)
        {
            return _repository.SingleOrDefault(item => GetId(item) == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.ToList();
        }

        public int GetId(T item)
        {
            var type = typeof (T);
            var idMemberName = string.Format("{0}Id", type.Name);
            var property = type.GetProperty(idMemberName);
            if (property == null)
            {
                throw new ArgumentException("Unable to determine ID property!");
            }
            ;
            var id = property.GetValue(item, new object[0]);

            if (id is int)
            {
                return (int) id;
            }

            throw new ArgumentException("Given item does not have valid key!");
        }
    }
}