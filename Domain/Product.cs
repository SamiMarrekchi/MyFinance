using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public DateTime DateProd { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? categorieId { get; set; }
        public virtual Category category { get; set; }
        public virtual ICollection<Provider> providers  { get; set; }

    }
}
