using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Provider
    {
        [StringLength(8)]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public DateTime DateCreated { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int id { get; set; }

        public bool IsApproved { get; set; }
        [StringLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
