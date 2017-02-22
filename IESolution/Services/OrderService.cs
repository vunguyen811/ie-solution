using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IESolution.Models;
using OfficeOpenXml;

namespace IESolution.Services
{
    public class OrderService
    {
        private ApplicationDbContext db;

        /// <summary>
        /// Get order by number records
        /// </summary>
        /// <param name="records">select top (records)</param>
        /// <returns></returns>
        public Task<List<Order>> GetOrdersAsync(int records)
        {
            if (records < 0) throw new ArgumentNullException(nameof(records));
            db = new ApplicationDbContext();
            string query = "SELECT TOP (@p0) * FROM [Orders]";
            return db.Database.SqlQuery<Order>(query, records).ToListAsync();
        }


        public Task<bool> ImportOrdersAsync(Stream data)
        {
            using (var excelPackage = new ExcelPackage(data))
            {
                var orders = new List<ImportedOrder>();
                var ws = excelPackage.Workbook.Worksheets.FirstOrDefault();
                if (ws == null || ws.Dimension == null)
                {
                    return Task.FromResult(false);
                }
                int totalRow = ws.Dimension.End.Row - ws.Dimension.Start.Row + 1;
                for (int i = 2; i <= totalRow; i++)
                {
                    var order = new ImportedOrder
                    {
                        Type = ws.Cells[i, 2].GetValue<string>() ?? string.Empty,
                        PartnerId = ws.Cells[i, 3].GetValue<string>() ?? string.Empty,
                        PartnerName = ws.Cells[i, 4].GetValue<string>() ?? string.Empty,
                        Mode = ws.Cells[i, 5].GetValue<string>() ?? string.Empty,
                        Status = ws.Cells[i, 6].GetValue<string>() ?? string.Empty,
                        StatusCode = ws.Cells[i, 7].GetValue<int?>() ?? 0,
                        Xid = ws.Cells[i, 8].GetValue<string>() ?? string.Empty,
                        Incident = ws.Cells[i, 9].GetValue<string>() ?? string.Empty,
                        Notes = ws.Cells[i, 10].GetValue<string>() ?? string.Empty,
                        ItemsQuantity = ws.Cells[i, 11].GetValue<int?>() ?? 0,
                        ItemsAmount = ws.Cells[i, 12].GetValue<int?>() ?? 0,
                        ItemsTax = ws.Cells[i, 13].GetValue<decimal?>() ?? 0,
                        BillingName = ws.Cells[i, 14].GetValue<string>() ?? string.Empty,
                        BillingAddress1 = ws.Cells[i, 15].GetValue<string>() ?? string.Empty,
                        BillingAddress2 = ws.Cells[i, 16].GetValue<string>() ?? string.Empty,
                        BillingCity = ws.Cells[i, 17].GetValue<string>() ?? string.Empty,
                        BillingState = ws.Cells[i, 18].GetValue<string>() ?? string.Empty,
                        BillingCountry = ws.Cells[i, 19].GetValue<string>() ?? string.Empty,
                        BillingZipcode = ws.Cells[i, 20].GetValue<string>() ?? string.Empty,
                        BillingPhone = ws.Cells[i, 21].GetValue<string>() ?? string.Empty,
                        BillingEmail = ws.Cells[i, 22].GetValue<string>() ?? string.Empty,
                        Tags = ws.Cells[i, 23].GetValue<string>() ?? string.Empty,
                        PrintedOnUtc = ws.Cells[i, 24].GetValue<DateTime?>(),
                        IsPrinted = ws.Cells[i, 25].GetValue<bool?>() ?? false,
                        PickedOnUtc = ws.Cells[i, 26].GetValue<DateTime?>(),
                        IsPicked = ws.Cells[i, 27].GetValue<bool?>() ?? false,
                        CancelledOnUtc = ws.Cells[i, 28].GetValue<DateTime?>(),
                        IsCancelled = ws.Cells[i, 29].GetValue<bool?>() ?? false,
                        CancelTypeId = ws.Cells[i, 30].GetValue<CancelTypes>(),
                        ShippingPriority = ws.Cells[i, 31].GetValue<int?>() ?? 0,
                        ShippingAccount = ws.Cells[i, 32].GetValue<string>() ?? string.Empty,
                        ShippingCarrier = ws.Cells[i, 33].GetValue<string>() ?? string.Empty,
                        ShippingName = ws.Cells[i, 34].GetValue<string>() ?? string.Empty,
                        ShippingAddress1 = ws.Cells[i, 35].GetValue<string>() ?? string.Empty,
                        ShippingAddress2 = ws.Cells[i, 36].GetValue<string>() ?? string.Empty,
                        ShippingCity = ws.Cells[i, 37].GetValue<string>() ?? string.Empty,
                        ShippingState = ws.Cells[i, 38].GetValue<string>() ?? string.Empty,
                        ShippingCountry = ws.Cells[i, 39].GetValue<string>() ?? string.Empty,
                        ShippingZipcode = ws.Cells[i, 40].GetValue<string>() ?? string.Empty,
                        ShippingPhone = ws.Cells[i, 41].GetValue<string>() ?? string.Empty,
                        ShippingEmail = ws.Cells[i, 42].GetValue<string>() ?? string.Empty,
                        Fax = ws.Cells[i, 43].GetValue<string>() ?? string.Empty,
                        ShippedOnUtc = ws.Cells[i, 44].GetValue<DateTime?>(),
                        IsShipped = ws.Cells[i, 45].GetValue<bool?>() ?? false
                    };
                    orders.Add(order);
                }

                db = new ApplicationDbContext();
                db.ImportedOrders.AddRange(orders);
                db.SaveChanges();

                return Task.FromResult(true);

            }
        }


        public Task<bool> ImportOrdersAsyncV2(Stream data)
        {
            using (var excelPackage = new ExcelPackage(data))
            {
                var orders = new List<ImportedOrder>();
                var ws = excelPackage.Workbook.Worksheets.FirstOrDefault();
                if (ws == null || ws.Dimension == null)
                {
                    return Task.FromResult(false);
                }
                int totalRow = ws.Dimension.End.Row - ws.Dimension.Start.Row + 1;
                for (int i = 2; i <= totalRow; i++)
                {
                    var order = new ImportedOrder
                    {
                        Type = ws.Cells[i, 2].GetValue<string>() ?? string.Empty,
                        PartnerId = ws.Cells[i, 3].GetValue<string>() ?? string.Empty,
                        PartnerName = ws.Cells[i, 4].GetValue<string>() ?? string.Empty,
                        Mode = ws.Cells[i, 5].GetValue<string>() ?? string.Empty,
                        Status = ws.Cells[i, 6].GetValue<string>() ?? string.Empty,
                        StatusCode = ws.Cells[i, 7].GetValue<int?>() ?? 0,
                        Xid = ws.Cells[i, 8].GetValue<string>() ?? string.Empty,
                        Incident = ws.Cells[i, 9].GetValue<string>() ?? string.Empty,
                        Notes = ws.Cells[i, 10].GetValue<string>() ?? string.Empty,
                        ItemsQuantity = ws.Cells[i, 11].GetValue<int?>() ?? 0,
                        ItemsAmount = ws.Cells[i, 12].GetValue<int?>() ?? 0,
                        ItemsTax = ws.Cells[i, 13].GetValue<decimal?>() ?? 0,
                        BillingName = ws.Cells[i, 14].GetValue<string>() ?? string.Empty,
                        BillingAddress1 = ws.Cells[i, 15].GetValue<string>() ?? string.Empty,
                        BillingAddress2 = ws.Cells[i, 16].GetValue<string>() ?? string.Empty,
                        BillingCity = ws.Cells[i, 17].GetValue<string>() ?? string.Empty,
                        BillingState = ws.Cells[i, 18].GetValue<string>() ?? string.Empty,
                        BillingCountry = ws.Cells[i, 19].GetValue<string>() ?? string.Empty,
                        BillingZipcode = ws.Cells[i, 20].GetValue<string>() ?? string.Empty,
                        BillingPhone = ws.Cells[i, 21].GetValue<string>() ?? string.Empty,
                        BillingEmail = ws.Cells[i, 22].GetValue<string>() ?? string.Empty,
                        Tags = ws.Cells[i, 23].GetValue<string>() ?? string.Empty,
                        PrintedOnUtc = ws.Cells[i, 24].GetValue<DateTime?>(),
                        IsPrinted = ws.Cells[i, 25].GetValue<bool?>() ?? false,
                        PickedOnUtc = ws.Cells[i, 26].GetValue<DateTime?>(),
                        IsPicked = ws.Cells[i, 27].GetValue<bool?>() ?? false,
                        CancelledOnUtc = ws.Cells[i, 28].GetValue<DateTime?>(),
                        IsCancelled = ws.Cells[i, 29].GetValue<bool?>() ?? false,
                        CancelTypeId = ws.Cells[i, 30].GetValue<CancelTypes>(),
                        ShippingPriority = ws.Cells[i, 31].GetValue<int?>() ?? 0,
                        ShippingAccount = ws.Cells[i, 32].GetValue<string>() ?? string.Empty,
                        ShippingCarrier = ws.Cells[i, 33].GetValue<string>() ?? string.Empty,
                        ShippingName = ws.Cells[i, 34].GetValue<string>() ?? string.Empty,
                        ShippingAddress1 = ws.Cells[i, 35].GetValue<string>() ?? string.Empty,
                        ShippingAddress2 = ws.Cells[i, 36].GetValue<string>() ?? string.Empty,
                        ShippingCity = ws.Cells[i, 37].GetValue<string>() ?? string.Empty,
                        ShippingState = ws.Cells[i, 38].GetValue<string>() ?? string.Empty,
                        ShippingCountry = ws.Cells[i, 39].GetValue<string>() ?? string.Empty,
                        ShippingZipcode = ws.Cells[i, 40].GetValue<string>() ?? string.Empty,
                        ShippingPhone = ws.Cells[i, 41].GetValue<string>() ?? string.Empty,
                        ShippingEmail = ws.Cells[i, 42].GetValue<string>() ?? string.Empty,
                        Fax = ws.Cells[i, 43].GetValue<string>() ?? string.Empty,
                        ShippedOnUtc = ws.Cells[i, 44].GetValue<DateTime?>(),
                        IsShipped = ws.Cells[i, 45].GetValue<bool?>() ?? false
                    };
                    orders.Add(order);
                }

                var query = new StringBuilder();
                foreach (var order in orders)
                {
                    query.Append(string.Format(@"INSERT INTO 
                                                [ImportedOrders] VALUES(
                                                '{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}',{9},{10},{11},'{12}','{13}','{14}','{15}','{16}','{17}',
                                                '{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}',{28},{29},'{30}','{31}','{32}','{33}','{34}','{35}',
                                                '{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}'); ",
                        order.Type, order.PartnerId, order.PartnerName, order.Mode, order.Status, order.StatusCode,
                        order.Xid, order.Incident, order.Notes,
                        order.ItemsQuantity, order.ItemsAmount, order.ItemsTax, order.BillingName, order.BillingAddress1,
                        order.BillingAddress2, order.BillingCity,
                        order.BillingState, order.BillingCountry, order.BillingZipcode, order.BillingPhone,
                        order.BillingEmail, order.Tags, order.PrintedOnUtc,
                        order.IsPrinted, order.PickedOnUtc, order.IsPicked, order.CancelledOnUtc, order.IsCancelled,
                        order.CancelTypeId, order.ShippingPriority,
                        order.ShippingAccount, order.ShippingCarrier, order.ShippingName, order.ShippingAddress1,
                        order.ShippingAddress2, order.ShippingCity,
                        order.ShippingState, order.ShippingCountry, order.ShippingZipcode, order.ShippingPhone,
                        order.ShippingEmail, order.Fax, order.ShippedOnUtc, order.IsShipped));
                }

                if (query.Length > 0)
                {
                    db = new ApplicationDbContext();
                    db.Database.ExecuteSqlCommand(query.ToString());
                }
                return Task.FromResult(true);

            }
        }

        public void DeleteImportedOrder()
        {
            db = new ApplicationDbContext();
            var query = "DELETE [ImportedOrders]";
            db.Database.ExecuteSqlCommand(query);
        }
    }
}