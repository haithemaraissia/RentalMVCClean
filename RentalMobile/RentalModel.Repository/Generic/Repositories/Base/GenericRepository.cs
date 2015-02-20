using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Generic.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        public DbSet<T> Dbset { get; private set; }

        public GenericRepository()
        {
            _context = new RentalContext();
            Dbset = _context.Set<T>();
        }

        public GenericRepository(DbContext context)
        {
            _context = context;
            Dbset = context.Set<T>();
        }

        public IQueryable<T> All
        {
            get { return Dbset.AsQueryable(); }
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = includeProperties.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(Dbset, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public T Find(T entity)
        {
            return Dbset.Find(entity);
        }

        public void Add(T entity)
        {
            Dbset.Add(entity);
            Save();
        }

        public void Insert(T entity)
        {
            Dbset.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            Dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Edit(T entity)
        {
            Dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            Dbset.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
