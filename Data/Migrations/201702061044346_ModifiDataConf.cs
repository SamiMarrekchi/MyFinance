namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiDataConf : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Myproducts");
            RenameTable(name: "dbo.ProviderProducts", newName: "productPro");
            RenameColumn(table: "dbo.productPro", name: "Provider_id", newName: "categorie");
            RenameColumn(table: "dbo.productPro", name: "Product_ProductId", newName: "product");
            RenameIndex(table: "dbo.productPro", name: "IX_Product_ProductId", newName: "IX_product");
            RenameIndex(table: "dbo.productPro", name: "IX_Provider_id", newName: "IX_categorie");
            DropPrimaryKey("dbo.productPro");
            AddColumn("dbo.Myproducts", "IsBiological", c => c.Int());
            AddPrimaryKey("dbo.productPro", new[] { "product", "categorie" });
            DropColumn("dbo.Myproducts", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Myproducts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.productPro");
            DropColumn("dbo.Myproducts", "IsBiological");
            AddPrimaryKey("dbo.productPro", new[] { "Provider_id", "Product_ProductId" });
            RenameIndex(table: "dbo.productPro", name: "IX_categorie", newName: "IX_Provider_id");
            RenameIndex(table: "dbo.productPro", name: "IX_product", newName: "IX_Product_ProductId");
            RenameColumn(table: "dbo.productPro", name: "product", newName: "Product_ProductId");
            RenameColumn(table: "dbo.productPro", name: "categorie", newName: "Provider_id");
            RenameTable(name: "dbo.productPro", newName: "ProviderProducts");
            RenameTable(name: "dbo.Myproducts", newName: "Products");
        }
    }
}
