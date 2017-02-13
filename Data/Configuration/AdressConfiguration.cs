using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Data.Configuration
{
    class AdressConfiguration :ComplexTypeConfiguration<Adress>
    {
        public AdressConfiguration() {
            Property(a => a.City).IsRequired();
            Property(a => a.StreetAddress).IsOptional();
        }
    }
}
