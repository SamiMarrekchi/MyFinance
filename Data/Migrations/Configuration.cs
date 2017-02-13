namespace Data.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.Context";
        }

        protected override void Seed(Data.Context context)
        {
            context.Categorys.AddOrUpdate(
               p => p.Name,  //Uniqueness property
               new Category { Name = "Medicament" },
               new Category { Name = "Vetement" },
               new Category { Name = "Meuble" }
             );
            context.SaveChanges();

        }
    }
}
