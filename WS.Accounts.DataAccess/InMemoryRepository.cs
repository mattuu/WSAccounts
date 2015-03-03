using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WS.Accounts.DataAccess
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly ICollection<T> _collection;

        public InMemoryRepository()
        {
            _collection = new Collection<T>();
        }

        public void Add(T item)
        {
            _collection.Add(item);

            var type = typeof(T);

            var idMemberName = string.Format("{0}Id", type.Name);
            var property = type.GetProperty(idMemberName);
            if (property == null) return;
            var id = property.GetValue(item, new object[0]);
            if (id is int && (int)id == 0)
                property.SetValue(item, _collection.Count(), new object[0]);
        }

        public void Update(T item)
        {
            if (!_collection.Contains(item)) return;

            var first = _collection.First(i => Equals(i, item));
            var type = typeof(T);
            foreach (var property in type.GetProperties().Where(p => p.CanWrite && p.CanRead))
            {
                property.SetValue(first, property.GetValue(item, new object[0]), new object[0]);
            }
        }

        public void Delete(T item)
        {
            _collection.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return _collection.AsQueryable<T>().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _collection.AsQueryable<T>().Provider ; }
        }

        public virtual void Submit()
        {
            
        }
    }
}