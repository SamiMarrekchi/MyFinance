
using System.Data.Entity.ModelConfiguration;

using Domain;

namespace Data.Configuration
{
    class ProductConfiguration:EntityTypeConfiguration<Product>
    {
       
           public  ProductConfiguration()
            {
            ToTable("Myproducts");     
            HasKey(x => x.ProductId);
            Property(x=>x.Name).IsRequired();
            //Relation *..(0..1)
            HasOptional(p => p.category).WithMany(c=>c.Products).HasForeignKey(p=>p.categorieId).WillCascadeOnDelete(false);
            //Relation *..*
            HasMany(x => x.providers).WithMany(p => p.products).Map(x=> { x.ToTable("productPro");
                x.MapLeftKey("product").MapRightKey("categorie");
                //Relation d'heritage
                Map<Biological>(b => b.Requires("IsBiological").HasValue(1));
                Map<Chemical>(b => b.Requires("IsBiological").HasValue(0));

            });
        }
    }
}
