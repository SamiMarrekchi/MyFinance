using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
    public interface IRepositoryBase<T> where T : class
    {
        void create(T entity);
        void update(T entity);
        void delete(T entity);
        T getById(String id);
        T getById(int id);
        IEnumerable<T> getByCondition(Expression<Func<T,bool>> condition=null, Expression<Func<T, bool>> orderby=null);

        T getByCondition(Expression<Func<T, bool>> condition = null);




        void deleteByCondition(Expression<Func<T, bool>> condition);
    }
}
