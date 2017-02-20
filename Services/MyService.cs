using Data.Infrastructures;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class MyService : IMyService
    {
      private  IDataBaseFactory dbFact=new DataBaseFactory();
      private IUnitofWork unitOfWork;

        
        public MyService()
        {
           unitOfWork = new UnitofWork(dbFact);

        }


        public int calculNbCategories()
        {
          return  unitOfWork.getRepository<Category>().getByCondition(null,null).Count();

        }

        public void createProduct(Product P)
        {
            unitOfWork.getRepository<Product>().create(P);
        }

        public void commit()
        {
            unitOfWork.commit();

        }
    }
}
