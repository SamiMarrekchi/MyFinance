using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Data.Configuration 
{
    class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("MyCategories");
            Property(p => p.Name).HasMaxLength(60).IsRequired();
        }
    }
}
