using Data.Configuration;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context : DbContext
    {
        public Context():base("MyFinanceDB"){ Database.SetInitializer<Context>(new ContextInitializer()); }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdressConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
          
            Category vetement = new Category()
            {
                Name = "vetement"
            };
            Category medicament = new Category()
            {
                Name = "medicament"
            };
            Category meuble = new Category()
            {
                Name = "meuble"
            };
            context.Categorys.Add(vetement);
            context.Categorys.Add(medicament);
            context.Categorys.Add(meuble);
            context.SaveChanges();
        }
      
    }
}
