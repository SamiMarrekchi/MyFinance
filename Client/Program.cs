using Data;
using Domain;
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
            Context ctxt = new Context();
            Category cat = new Category
            {
                Name = "Category1",

            };
            ctxt.Categorys.Add(cat);
            ctxt.SaveChanges();
            System.Console.WriteLine("sauvgarde reussie");
            Console.ReadKey();

        }
    }
}
