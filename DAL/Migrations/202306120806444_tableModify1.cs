namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableModify1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            DropColumn("dbo.Admins", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Password", c => c.String());
            DropTable("dbo.Users");
        }
    }
}
