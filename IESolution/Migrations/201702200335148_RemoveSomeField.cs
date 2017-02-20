namespace IESolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSomeField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "SortedOnUtc");
            DropColumn("dbo.Orders", "IsSorted");
            DropColumn("dbo.Orders", "Bol");
            DropColumn("dbo.Orders", "IsCompleted");
            DropColumn("dbo.Orders", "TscOrderId");
            DropColumn("dbo.Orders", "PackingList");
            DropColumn("dbo.Orders", "IsAsnStatus");
            DropColumn("dbo.Orders", "AsnCount");
            DropColumn("dbo.Orders", "AsnSentOnUtc");
            DropColumn("dbo.Orders", "IsReleaseNotificationStatus");
            DropColumn("dbo.Orders", "ReleaseNotificationCount");
            DropColumn("dbo.Orders", "ReleaseNotificationSentOnUtc");
            DropColumn("dbo.Orders", "IsCancelNotificationStatus");
            DropColumn("dbo.Orders", "CancelNotificationCount");
            DropColumn("dbo.Orders", "CancelNotificationSentOnUtc");
            DropColumn("dbo.Orders", "CancelReason");
            DropColumn("dbo.Orders", "IsWholesale");
            DropColumn("dbo.Orders", "GiftNoteComment");
            DropColumn("dbo.Orders", "SlaDateOnUtc");
            DropColumn("dbo.Orders", "MergedOnUtc");
            DropColumn("dbo.Orders", "ReturnedOnUtc");
            DropColumn("dbo.Orders", "CreditAmount");
            DropColumn("dbo.Orders", "InvoiceAmount");
            DropColumn("dbo.Orders", "ShippingAmount");
            DropColumn("dbo.Orders", "CreditedOnUtc");
            DropColumn("dbo.Orders", "IsDropped");
            DropColumn("dbo.Orders", "DroppedOnUtc");
            DropColumn("dbo.Orders", "Suffix");
            DropColumn("dbo.Orders", "StatusTransition");
            DropColumn("dbo.Orders", "IsInvoiced");
            DropColumn("dbo.Orders", "InvoicedOnUtc");
            DropColumn("dbo.Orders", "BaseOrderId");
            DropColumn("dbo.Orders", "IsAlertAdmin");
            DropColumn("dbo.Orders", "StatusUpdateUrl");
            DropColumn("dbo.Orders", "OrderType");
            DropColumn("dbo.Orders", "InvoiceWeek");
            DropColumn("dbo.Orders", "PacklogoUrl");
            DropColumn("dbo.Orders", "AcceptedOnUtc");
            DropColumn("dbo.Orders", "PackcopyBlock1");
            DropColumn("dbo.Orders", "PackcopyBlock2");
            DropColumn("dbo.Orders", "ReturnName");
            DropColumn("dbo.Orders", "ReturnAddress1");
            DropColumn("dbo.Orders", "ReturnAddress2");
            DropColumn("dbo.Orders", "ReturnCity");
            DropColumn("dbo.Orders", "ReturnState");
            DropColumn("dbo.Orders", "ReturnCountry");
            DropColumn("dbo.Orders", "ReturnZipcode");
            DropColumn("dbo.Orders", "ReturnEmail");
            DropColumn("dbo.Orders", "ShippingCompany");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ShippingCompany", c => c.String());
            AddColumn("dbo.Orders", "ReturnEmail", c => c.String());
            AddColumn("dbo.Orders", "ReturnZipcode", c => c.String());
            AddColumn("dbo.Orders", "ReturnCountry", c => c.String());
            AddColumn("dbo.Orders", "ReturnState", c => c.String());
            AddColumn("dbo.Orders", "ReturnCity", c => c.String());
            AddColumn("dbo.Orders", "ReturnAddress2", c => c.String());
            AddColumn("dbo.Orders", "ReturnAddress1", c => c.String());
            AddColumn("dbo.Orders", "ReturnName", c => c.String());
            AddColumn("dbo.Orders", "PackcopyBlock2", c => c.String());
            AddColumn("dbo.Orders", "PackcopyBlock1", c => c.String());
            AddColumn("dbo.Orders", "AcceptedOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "PacklogoUrl", c => c.String());
            AddColumn("dbo.Orders", "InvoiceWeek", c => c.String(maxLength: 10));
            AddColumn("dbo.Orders", "OrderType", c => c.String(maxLength: 10));
            AddColumn("dbo.Orders", "StatusUpdateUrl", c => c.String(maxLength: 450));
            AddColumn("dbo.Orders", "IsAlertAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "BaseOrderId", c => c.Int());
            AddColumn("dbo.Orders", "InvoicedOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "IsInvoiced", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "StatusTransition", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Suffix", c => c.Int());
            AddColumn("dbo.Orders", "DroppedOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "IsDropped", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "CreditedOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "ShippingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "InvoiceAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "CreditAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ReturnedOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "MergedOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "SlaDateOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "GiftNoteComment", c => c.String());
            AddColumn("dbo.Orders", "IsWholesale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "CancelReason", c => c.String(maxLength: 450));
            AddColumn("dbo.Orders", "CancelNotificationSentOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "CancelNotificationCount", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "IsCancelNotificationStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "ReleaseNotificationSentOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "ReleaseNotificationCount", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "IsReleaseNotificationStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "AsnSentOnUtc", c => c.DateTime());
            AddColumn("dbo.Orders", "AsnCount", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "IsAsnStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "PackingList", c => c.String(maxLength: 250));
            AddColumn("dbo.Orders", "TscOrderId", c => c.Int());
            AddColumn("dbo.Orders", "IsCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Bol", c => c.String(maxLength: 250));
            AddColumn("dbo.Orders", "IsSorted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "SortedOnUtc", c => c.DateTime());
        }
    }
}
