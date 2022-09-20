using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Xolit.Whatsapp.DataAccess.Repositories.Imp
{
    public interface IRepository<T> where T : class
    {
        T SingleFindBy(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes);
        int CoutFindBy(Expression<Func<T, bool>> predicate);

        T SingleFindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        void Insert(T entity);

        void Update(T entity);
    }
}
