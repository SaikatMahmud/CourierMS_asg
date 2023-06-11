namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Couriers",
                c => new
                    {
                        ConsignmentNo = c.Int(nullable: false, identity: true),
                        ParcelType = c.String(),
                        Weight = c.String(),
                        ShippingCost = c.Int(nullable: false),
                        PlacingDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        CurrentLocation = c.String(),
                        Destination = c.String(),
                        ETA = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ConsignmentNo);
            
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        ConsignmentNo = c.Int(nullable: false),
                        SenderName = c.String(),
                        SenderMobile = c.String(),
                        SenderAddress = c.String(),
                        ReceiverName = c.String(),
                        ReceiverMobile = c.String(),
                        ReceiverAddress = c.String(),
                    })
                .PrimaryKey(t => t.ConsignmentNo)
                .ForeignKey("dbo.Couriers", t => t.ConsignmentNo)
                .Index(t => t.ConsignmentNo);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        CreatedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerInfoes", "ConsignmentNo", "dbo.Couriers");
            DropIndex("dbo.CustomerInfoes", new[] { "ConsignmentNo" });
            DropTable("dbo.Tokens");
            DropTable("dbo.CustomerInfoes");
            DropTable("dbo.Couriers");
            DropTable("dbo.Admins");
        }
    }
}
