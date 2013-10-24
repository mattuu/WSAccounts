using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace WS.Accounts.Site.Models.DataStore
{
    public interface IRepository<T> : IQueryable<T>
    {
        void Add(T item);

        void Update(T item);

        void Delete(T item);

        void Submit();
    }

    public class DbContextRepository<T> : IRepository<T> where T : class, new()
    {
        private DbContext _context;

        public DbContextRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _context.Set<T>().Attach(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _context.Set<T>().AsQueryable().GetEnumerator();
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
            get
            {
                return _context.Set<T>().AsQueryable<T>().Expression;
            }
        }

        public IQueryProvider Provider
        {
            get { return _context.Set<T>().AsQueryable<T>().Provider; }
        }


        public void Submit()
        {
            _context.SaveChanges();
        }
    }

    public class InMemoryRepository<T> : IRepository<T>
    {
        private ICollection<T> _collection;

        public InMemoryRepository()
        {
            _collection = new Collection<T>();
        }

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public void Update(T item)
        {
            var first = _collection.First(t => EqualityComparer<T>.Default.Equals(t, item));

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