using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebApiyleApi.Models;

namespace WebApiyleApi.Classes
{
    public class MyGenericRepo<T, Context> : 
        IRepoDesign<T> where T : Identity where Context : DbContext, new() 
    {
        private Context _context = new Context();
        public Context Contexts {
            get { return _context; }
            set { _context = value; } }


        public virtual IList<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public virtual IList<T> GetWithWhere(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public virtual T InsertEntity(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            SaveChanges();
            return result;
        }

        public virtual bool UpdateEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = SaveChanges();
            if (result > 0) { return true; } else { return false; }
        }

        public virtual bool DeleteEntity(T entity)
        {
            //_context.Set<T>().Remove(entity); Bu şekilde de kullanabilirsiniz.
            _context.Entry(entity).State = EntityState.Deleted; //Bu şekilde de 
            var result = SaveChanges();
            if (result > 0) { return true; } else { return false; }
        }

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}