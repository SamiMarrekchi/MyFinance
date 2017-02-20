
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  interface IMyService
    {

         void createProduct(Product P);
         int calculNbCategories();
    }
}
