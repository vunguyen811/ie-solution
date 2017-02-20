using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IESolution.Helper;
using IESolution.Models;

namespace IESolution.BackgroundJob
{
    public static class BackgroundJob 
    {
        private static ApplicationDbContext db;

        public static void CreateOrder()
        {
            var orders = new List<Order>();
            Parallel.For(0, 1000, i =>
            {
                var order = new Order
                {
                    Type = CommonHelper.GenerateString(),
                    PartnerId = CommonHelper.GenerateString(),
                    PartnerName = CommonHelper.GenerateString(),
                    Mode = CommonHelper.GenerateString(),
                    Status = CommonHelper.GenerateString(),
                    StatusCode = CommonHelper.GenerateDigit(),
                    Xid = CommonHelper.GenerateString(),
                    Incident = CommonHelper.GenerateString(),
                    Notes = CommonHelper.GenerateString(),
                    ItemsQuantity = CommonHelper.GenerateDigit(),
                    ItemsAmount = CommonHelper.GenerateDigit(),
                    ItemsTax = CommonHelper.GenerateDigit(),
                    BillingName = CommonHelper.GenerateString(),
                    BillingAddress1 = CommonHelper.GenerateString(),
                    BillingAddress2 = CommonHelper.GenerateString(),
                    BillingCity = CommonHelper.GenerateString(),
                    BillingState = CommonHelper.GenerateString(),
                    BillingCountry = CommonHelper.GenerateString(),
                    BillingZipcode = CommonHelper.GenerateString(),
                    BillingPhone = CommonHelper.GenerateString(),
                    BillingEmail = CommonHelper.GenerateString(),
                    Tags = CommonHelper.GenerateString(),
                    PrintedOnUtc = DateTime.UtcNow,
                    IsPrinted = true,
                    PickedOnUtc = DateTime.UtcNow,
                    IsPicked = true,
                    CancelledOnUtc = DateTime.UtcNow,
                    IsCancelled = true,
                    CancelTypeId = CancelTypes.CancelledWithCharge,
                    ShippingPriority = CommonHelper.GenerateDigit(),
                    ShippingAccount = CommonHelper.GenerateString(),
                    ShippingCarrier = CommonHelper.GenerateString(),
                    ShippingName = CommonHelper.GenerateString(),
                    ShippingAddress1 = CommonHelper.GenerateString(),
                    ShippingAddress2 = CommonHelper.GenerateString(),
                    ShippingCity = CommonHelper.GenerateString(),
                    ShippingState = CommonHelper.GenerateString(),
                    ShippingCountry = CommonHelper.GenerateString(),
                    ShippingZipcode = CommonHelper.GenerateString(),
                    ShippingPhone = CommonHelper.GenerateString(),
                    ShippingEmail = CommonHelper.GenerateString(),
                    Fax = CommonHelper.GenerateString(),
                    ShippedOnUtc = DateTime.UtcNow,
                    IsShipped = true
                };
                orders.Add(order);
            });
            db = new ApplicationDbContext();
            db.Orders.AddRange(orders);
            db.SaveChanges();

        }
    }
}