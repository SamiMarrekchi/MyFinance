using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
   public interface IUnitofWork:IDisposable
    {
        void commit();

        IRepositoryBase<T> getRepository<T>() where T:class;


    }
}
