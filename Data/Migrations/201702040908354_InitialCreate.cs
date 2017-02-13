namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        DateProd = c.DateTime(nullable: false),
                        Description = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(),
                        categorieId = c.Int(),
                        Herbes = c.String(),
                        City = c.String(),
                        LabName = c.String(),
                        StreetAddress = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.category_CategoryId)
                .Index(t => t.category_CategoryId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ConfirmPassword = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Email = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        Password = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProviderProducts",
                c => new
                    {
                        Provider_id = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_id, t.Product_ProductId })
                .ForeignKey("dbo.Providers", t => t.Provider_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Provider_id)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProviderProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProviderProducts", "Provider_id", "dbo.Providers");
            DropForeignKey("dbo.Products", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.ProviderProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.ProviderProducts", new[] { "Provider_id" });
            DropIndex("dbo.Products", new[] { "category_CategoryId" });
            DropTable("dbo.ProviderProducts");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
