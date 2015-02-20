using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RentalModel.Repository.Generic.Repositories.Base
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Find(T entity);
         void Add(T entity);
        void Insert(T entity);
        void Update(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Save();
    }
}
