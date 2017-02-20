using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
       public class DataBaseFactory : Disposable,IDataBaseFactory
    {
        private Context context;
        public Context Mycontext
        {
            get
            {
                return context;
            }
        }
    


    public DataBaseFactory()
    {
        context = new Context(); 
    }

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }

    }
}
