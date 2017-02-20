using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace Data.Infrastructures
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDataBaseFactory dbFactory;
        private Context context;
        readonly IDbSet<T> dbset;


        public Context MyContext { get { return dbFactory.Mycontext; } }
        public RepositoryBase(IDataBaseFactory dbFactory) {
            this.dbFactory = dbFactory;
            dbset = MyContext.Set<T>();
        }
       

      
       

        public void commit() { context.SaveChanges(); }
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

        public IEnumerable<T> getByCondition(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            if (condition == null && orderBy == null)
                return dbset;
            else if (condition != null && orderBy == null)
                return dbset.Where(condition);
            else if (condition == null && orderBy != null)
                return dbset.OrderBy(orderBy);
            else return dbset.Where(condition).OrderBy(orderBy);
        }


        public T getById(int id)
        {
            return dbset.Find(id);
        }

        public T getById(string id)
        {
            return dbset.Find(id);
        }

        public void update(T entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
