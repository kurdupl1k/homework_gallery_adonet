namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtblUsersandtblImagestoDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblImages", "UserOf_Id", "dbo.tblUsers");
            DropIndex("dbo.tblImages", new[] { "UserOf_Id" });
            RenameColumn(table: "dbo.tblImages", name: "UserOf_Id", newName: "UserId");
            AlterColumn("dbo.tblImages", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblImages", "UserId");
            AddForeignKey("dbo.tblImages", "UserId", "dbo.tblUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblImages", "UserId", "dbo.tblUsers");
            DropIndex("dbo.tblImages", new[] { "UserId" });
            AlterColumn("dbo.tblImages", "UserId", c => c.Int());
            RenameColumn(table: "dbo.tblImages", name: "UserId", newName: "UserOf_Id");
            CreateIndex("dbo.tblImages", "UserOf_Id");
            AddForeignKey("dbo.tblImages", "UserOf_Id", "dbo.tblUsers", "Id");
        }
    }
}
