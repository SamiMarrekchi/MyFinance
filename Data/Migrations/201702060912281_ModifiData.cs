namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "categorieId");
            RenameColumn(table: "dbo.Products", name: "category_CategoryId", newName: "categorieId");
            RenameIndex(table: "dbo.Products", name: "IX_category_CategoryId", newName: "IX_categorieId");
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Providers", "Password", c => c.String(maxLength: 8));
            DropColumn("dbo.Providers", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Providers", "Password", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            RenameIndex(table: "dbo.Products", name: "IX_categorieId", newName: "IX_category_CategoryId");
            RenameColumn(table: "dbo.Products", name: "categorieId", newName: "category_CategoryId");
            AddColumn("dbo.Products", "categorieId", c => c.Int());
        }
    }
}
