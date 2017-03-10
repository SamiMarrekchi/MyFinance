using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {

        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Error")]
        [MaxLength(50, ErrorMessage = "Error")]

        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Key]
        public int ProductId { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        public string ImageName { get; set; }

        
        public int? categorieId { get; set; }

        [ForeignKey("categorieId")]
        public virtual Category category { get; set; }
        
        public virtual ICollection<Provider> providers  { get; set; }

    }
}
