﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Provider
    {
        public string ConfirmPassword { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public int id { get; set; }

        public bool IsApproved { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
