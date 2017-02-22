using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using IESolution.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace IESolution.Services
{
    public class ExportService
    {
        public void ExportOrder(Stream stream, List<Order> orders)
        {
            if (stream == null) throw new ArgumentException(nameof(stream));
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get handle to the existing worksheet
                var worksheet = xlPackage.Workbook.Worksheets.Add("Orders");

                //Create Headers and format them 
                var properties = new[]
                {
                    "Id",
                    "Type",
                    "PartnerId",
                    "PartnerName",
                    "Mode",
                    "Status",
                    "StatusCode",
                    "Xid",
                    "Incident",
                    "Notes",
                    "ItemsQuantity",
                    "ItemsAmount",
                    "ItemsTax",
                    "BillingName",
                    "BillingAddress1",
                    "BillingAddress2",
                    "BillingCity",
                    "BillingState",
                    "BillingCountry",
                    "BillingZipcode",
                    "BillingPhone",
                    "BillingEmail",
                    "Tags",
                    "PrintedOnUtc",
                    "IsPrinted",
                    "PickedOnUtc",
                    "IsPicked",
                    "CancelledOnUtc",
                    "IsCancelled",
                    "CancelTypeId",
                    "ShippingPriority",
                    "ShippingAccount",
                    "ShippingCarrier",
                    "ShippingName",
                    "ShippingAddress1",
                    "ShippingAddress2",
                    "ShippingCity",
                    "ShippingState",
                    "ShippingCountry",
                    "ShippingZipcode",
                    "ShippingPhone",
                    "ShippingEmail",
                    "Fax",
                    "ShippedOnUtc",
                    "IsShipped"
                };

                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i];
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                }
                int row = 2;
                foreach (var order in orders)
                {
                    int col = 1;
                    worksheet.Cells[row, col].Value = order.Id;
                    col++;

                    worksheet.Cells[row, col].Value = order.Type;
                    col++;

                    worksheet.Cells[row, col].Value = order.PartnerId;
                    col++;

                    worksheet.Cells[row, col].Value = order.PartnerName;
                    col++;

                    worksheet.Cells[row, col].Value = order.Mode;
                    col++;

                    worksheet.Cells[row, col].Value = order.Status;
                    col++;

                    worksheet.Cells[row, col].Value = order.StatusCode;
                    col++;

                    worksheet.Cells[row, col].Value = order.Xid;
                    col++;

                    worksheet.Cells[row, col].Value = order.Incident;
                    col++;

                    worksheet.Cells[row, col].Value = order.Notes;
                    col++;

                    worksheet.Cells[row, col].Value = order.ItemsQuantity;
                    col++;

                    worksheet.Cells[row, col].Value = order.ItemsAmount;
                    col++;

                    worksheet.Cells[row, col].Value = order.ItemsTax;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingName;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingAddress1;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingAddress2;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingCity;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingState;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingCountry;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingZipcode;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingPhone;
                    col++;

                    worksheet.Cells[row, col].Value = order.BillingEmail;
                    col++;

                    worksheet.Cells[row, col].Value = order.Tags;
                    col++;

                    worksheet.Cells[row, col].Value = order.PrintedOnUtc?.ToString("MM-dd-yyyy hh:mm:ss tt") ?? "";
                    col++;

                    worksheet.Cells[row, col].Value = order.IsPrinted ? 1 : 0;
                    col++;

                    worksheet.Cells[row, col].Value = order.PickedOnUtc?.ToString("MM-dd-yyyy hh:mm:ss tt") ?? "";
                    col++;

                    worksheet.Cells[row, col].Value = order.IsPicked ? 1 : 0;
                    col++;

                    worksheet.Cells[row, col].Value = order.CancelledOnUtc?.ToString("MM-dd-yyyy hh:mm:ss tt") ?? "";
                    col++;

                    worksheet.Cells[row, col].Value = order.IsCancelled ? 1 : 0;
                    col++;

                    worksheet.Cells[row, col].Value = (int) order.CancelTypeId;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingPriority;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingAccount;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingCarrier;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingName;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingAddress1;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingAddress2;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingCity;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingState;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingCountry;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingZipcode;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingPhone;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippingEmail;
                    col++;

                    worksheet.Cells[row, col].Value = order.Fax;
                    col++;

                    worksheet.Cells[row, col].Value = order.ShippedOnUtc?.ToString("MM-dd-yyyy hh:mm:ss tt") ?? "";
                    col++;

                    worksheet.Cells[row, col].Value = order.IsShipped ? 1 : 0;
                    row++;
                }
                xlPackage.Save();
            }
        }

        public byte[] ExportOrder(List<Order> orders)
        {
            byte[] bytes;
            using (var stream = new MemoryStream())
            {
                ExportOrder(stream, orders);
                bytes = stream.ToArray();
            }

            return bytes;
        }
    }
}