namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtblUsersandtblImagestodatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.String(nullable: false, maxLength: 500),
                        UserOf_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.UserOf_Id)
                .Index(t => t.UserOf_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblImages", "UserOf_Id", "dbo.tblUsers");
            DropIndex("dbo.tblImages", new[] { "UserOf_Id" });
            DropTable("dbo.tblImages");
            DropTable("dbo.tblUsers");
        }
    }
}
