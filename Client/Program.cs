
using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
       
        static void Main(string[] args)
        {

            Product prd = new Product()
            {
                Name = "chemise",
                
                DateProd = new DateTime(2017, 02, 20),
                Description = "desc",
                Quantity = 250


            };
            MyService service = new MyService();
            service.createProduct(prd);

            service.commit();


            Console.WriteLine("le nombre de category est " + service.calculNbCategories());
            Console.ReadKey();

        }
    }
}
