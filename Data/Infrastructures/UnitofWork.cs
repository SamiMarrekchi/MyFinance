using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
    public class UnitofWork : IUnitofWork
    {
        private IDataBaseFactory dbFactory;
        private Context context;
        public UnitofWork(IDataBaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            context = dbFactory.Mycontext;
        }

        public void commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            return new RepositoryBase<T>(dbFactory);
        }
    }
}
