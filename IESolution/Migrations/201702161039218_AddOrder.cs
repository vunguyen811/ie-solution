namespace IESolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
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
                        SortedOnUtc = c.DateTime(),
                        IsSorted = c.Boolean(nullable: false),
                        Bol = c.String(maxLength: 250),
                        IsCompleted = c.Boolean(nullable: false),
                        TscOrderId = c.Int(),
                        PackingList = c.String(maxLength: 250),
                        IsAsnStatus = c.Boolean(nullable: false),
                        AsnCount = c.Int(nullable: false),
                        AsnSentOnUtc = c.DateTime(),
                        IsReleaseNotificationStatus = c.Boolean(nullable: false),
                        ReleaseNotificationCount = c.Int(nullable: false),
                        ReleaseNotificationSentOnUtc = c.DateTime(),
                        IsCancelNotificationStatus = c.Boolean(nullable: false),
                        CancelNotificationCount = c.Int(nullable: false),
                        CancelNotificationSentOnUtc = c.DateTime(),
                        CancelReason = c.String(maxLength: 450),
                        IsWholesale = c.Boolean(nullable: false),
                        GiftNoteComment = c.String(),
                        SlaDateOnUtc = c.DateTime(),
                        MergedOnUtc = c.DateTime(),
                        ReturnedOnUtc = c.DateTime(),
                        CreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditedOnUtc = c.DateTime(),
                        IsDropped = c.Boolean(nullable: false),
                        DroppedOnUtc = c.DateTime(),
                        Suffix = c.Int(),
                        StatusTransition = c.Int(nullable: false),
                        IsInvoiced = c.Boolean(nullable: false),
                        InvoicedOnUtc = c.DateTime(),
                        BaseOrderId = c.Int(),
                        IsAlertAdmin = c.Boolean(nullable: false),
                        StatusUpdateUrl = c.String(maxLength: 450),
                        OrderType = c.String(maxLength: 10),
                        InvoiceWeek = c.String(maxLength: 10),
                        PacklogoUrl = c.String(),
                        AcceptedOnUtc = c.DateTime(),
                        PackcopyBlock1 = c.String(),
                        PackcopyBlock2 = c.String(),
                        ReturnName = c.String(),
                        ReturnAddress1 = c.String(),
                        ReturnAddress2 = c.String(),
                        ReturnCity = c.String(),
                        ReturnState = c.String(),
                        ReturnCountry = c.String(),
                        ReturnZipcode = c.String(),
                        ReturnEmail = c.String(),
                        ShippingCompany = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.BillingName)
                .Index(t => t.Tags)
                .Index(t => t.ShippingName);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Orders", new[] { "ShippingName" });
            DropIndex("dbo.Orders", new[] { "Tags" });
            DropIndex("dbo.Orders", new[] { "BillingName" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Orders");
        }
    }
}
