using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private Context ctxt;
    
        readonly IDbSet<T> dbset;
        public RepositoryBase(Context ctxt) {
            this.ctxt = ctxt;
            dbset = ctxt.Set<T>();
        }

        public void commit() { ctxt.SaveChanges(); }
        public void create(T entity)
        {
            dbset.Add(entity);
        }

        public void delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void deleteByCondition(Expression<Func<T,bool>> condition)
        {
            IEnumerable<T> ListRemove = dbset.Where(condition);

            foreach (var item in ListRemove)
            {
                dbset.Remove(item);
            }

        }

        public T getByCondition(Expression<Func<T, bool>> condition = null)
        {
            return dbset.Where(condition).First();
        }

        public IEnumerable<T> getByCondition(Expression<Func<T, bool>> condition, Expression<Func<T, bool>> orderby)
        {
           
           
       
            return dbset.Where(condition).OrderBy(orderby) ;


        }

        public T getById(int id)
        {
            throw new NotImplementedException();
        }

        public T getById(string id)
        {
            throw new NotImplementedException();
        }

        public void update(T entity)
        {
            dbset.Attach(entity);
            ctxt.Entry(entity).State = EntityState.Modified;

        }
    }
}
