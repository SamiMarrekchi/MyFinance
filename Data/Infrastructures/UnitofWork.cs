using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
    public class UnitofWork : IUnitofWork
    {

        private Context context;
        public UnitofWork(Context context) { this.context = context; }

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
            return new RepositoryBase<T>(context);
        }
    }
}
