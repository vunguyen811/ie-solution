namespace IESolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImportedOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportedOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 250),
                        PartnerId = c.String(maxLength: 128),
                        PartnerName = c.String(maxLength: 450),
                        Mode = c.String(maxLength: 250),
                        Status = c.String(maxLength: 250),
                        StatusCode = c.Int(nullable: false),
                        Xid = c.String(maxLength: 128),
                        Incident = c.String(maxLength: 450),
                        Notes = c.String(),
                        ItemsQuantity = c.Int(nullable: false),
                        ItemsAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemsTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillingName = c.String(maxLength: 450),
                        BillingAddress1 = c.String(maxLength: 450),
                        BillingAddress2 = c.String(maxLength: 450),
                        BillingCity = c.String(maxLength: 450),
                        BillingState = c.String(maxLength: 250),
                        BillingCountry = c.String(maxLength: 250),
                        BillingZipcode = c.String(maxLength: 250),
                        BillingPhone = c.String(maxLength: 250),
                        BillingEmail = c.String(maxLength: 250),
                        Tags = c.String(maxLength: 450),
                        PrintedOnUtc = c.DateTime(),
                        IsPrinted = c.Boolean(nullable: false),
                        PickedOnUtc = c.DateTime(),
                        IsPicked = c.Boolean(nullable: false),
                        CancelledOnUtc = c.DateTime(),
                        IsCancelled = c.Boolean(nullable: false),
                        CancelTypeId = c.Int(nullable: false),
                        ShippingPriority = c.Int(nullable: false),
                        ShippingAccount = c.String(maxLength: 250),
                        ShippingCarrier = c.String(maxLength: 250),
                        ShippingName = c.String(maxLength: 450),
                        ShippingAddress1 = c.String(maxLength: 450),
                        ShippingAddress2 = c.String(maxLength: 450),
                        ShippingCity = c.String(maxLength: 450),
                        ShippingState = c.String(maxLength: 250),
                        ShippingCountry = c.String(maxLength: 250),
                        ShippingZipcode = c.String(maxLength: 250),
                        ShippingPhone = c.String(maxLength: 250),
                        ShippingEmail = c.String(maxLength: 250),
                        Fax = c.String(maxLength: 250),
                        ShippedOnUtc = c.DateTime(),
                        IsShipped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.BillingName)
                .Index(t => t.Tags)
                .Index(t => t.ShippingName);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ImportedOrders", new[] { "ShippingName" });
            DropIndex("dbo.ImportedOrders", new[] { "Tags" });
            DropIndex("dbo.ImportedOrders", new[] { "BillingName" });
            DropTable("dbo.ImportedOrders");
        }
    }
}
