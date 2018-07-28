using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApiyleApi.Classes
{
    interface IRepoDesign<T>
    {
        IList<T> GetList();
        IList<T> GetWithWhere(Expression<Func<T, bool>> predicate);
        T InsertEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
    }
}
