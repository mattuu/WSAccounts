using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WS.Accounts.DataAccess
{
    public class DbContextRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _context;

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
}