using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IESolution.Models
{
    public class Order
    {
        public int Id { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [MaxLength(250)]
        public string Type { get; set; }

        //Partner Id
        [MaxLength(128)]
        public string PartnerId { get; set; }

        /// <summary>
        /// Partner Name
        /// </summary>
        [MaxLength(450)]
        public string PartnerName { get; set; }

        /// <summary>
        /// Mode
        /// </summary>
        [MaxLength(250)]
        public string Mode { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [MaxLength(250)]
        public string Status { get; set; }

        /// <summary>
        /// StatusCode
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Xid
        /// </summary>
        [MaxLength(128)]
        public string Xid { get; set; }

        /// <summary>
        /// Incident
        /// </summary>
        [MaxLength(450)]
        public string Incident { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// ItemsQuantity
        /// </summary>
        public int ItemsQuantity { get; set; }

        /// <summary>
        /// ItemsAmount
        /// </summary>
        public decimal ItemsAmount { get; set; }

        /// <summary>
        /// ItemsTax
        /// </summary>
        public decimal ItemsTax { get; set; }

        /// <summary>
        /// BillingName
        /// </summary>
        [Index]
        [MaxLength(450)]
        public string BillingName { get; set; }

        /// <summary>
        /// BillingAddress1
        /// </summary>
        [MaxLength(450)]
        public string BillingAddress1 { get; set; }

        /// <summary>
        /// BillingAddress2
        /// </summary>
        [MaxLength(450)]
        public string BillingAddress2 { get; set; }

        /// <summary>
        /// BillingCity
        /// </summary>
        [MaxLength(450)]
        public string BillingCity { get; set; }

        /// <summary>
        /// BillingState
        /// </summary>
        [MaxLength(250)]
        public string BillingState { get; set; }

        /// <summary>
        /// BillingCountry
        /// </summary>
        [MaxLength(250)]
        public string BillingCountry { get; set; }

        /// <summary>
        /// BillingZipcode
        /// </summary>
        [MaxLength(250)]
        public string BillingZipcode { get; set; }

        /// <summary>
        /// BillingPhone
        /// </summary>
        [MaxLength(250)]
        public string BillingPhone { get; set; }

        /// <summary>
        /// BillingEmail
        /// </summary>
        [MaxLength(250)]
        public string BillingEmail { get; set; }

        /// <summary>
        /// Tags
        /// </summary>
        [Index]
        [MaxLength(450)]
        public string Tags { get; set; }

        // PrintedOnUtc
        public DateTime? PrintedOnUtc { get; set; }

        /// <summary>
        /// IsPrinted
        /// </summary>
        public bool IsPrinted { get; set; }

        /// <summary>
        /// PickedOnUtc
        /// </summary>
        public DateTime? PickedOnUtc { get; set; }

        /// <summary>
        /// IsPicked
        /// </summary>
        public bool IsPicked { get; set; }

        /// <summary>
        /// CancelledOnUtc
        /// </summary>
        public DateTime? CancelledOnUtc { get; set; }

        /// <summary>
        /// IsCancelled
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// CancelType
        /// </summary>
        public CancelTypes CancelTypeId { get; set; }

        /// <summary>
        /// ShippingPriority
        /// </summary>
        public int ShippingPriority { get; set; }

        /// <summary>
        /// ShippingAccount
        /// </summary>
        [MaxLength(250)]
        public string ShippingAccount { get; set; }

        /// <summary>
        /// ShippingCarrier
        /// </summary>
        [MaxLength(250)]
        public string ShippingCarrier { get; set; }

        /// <summary>
        /// ShippingName
        /// </summary>
        [Index]
        [MaxLength(450)]
        public string ShippingName { get; set; }

        /// <summary>
        /// ShippingAddress1
        /// </summary>
        [MaxLength(450)]
        public string ShippingAddress1 { get; set; }

        /// <summary>
        /// ShippingAddress2
        /// </summary>
        [MaxLength(450)]
        public string ShippingAddress2 { get; set; }

        /// <summary>
        /// ShippingCity
        /// </summary>
        [MaxLength(450)]
        public string ShippingCity { get; set; }

        /// <summary>
        /// ShippingState
        /// </summary>
        [MaxLength(250)]
        public string ShippingState { get; set; }

        /// <summary>
        /// ShippingCountry
        /// </summary>
        [MaxLength(250)]
        public string ShippingCountry { get; set; }

        /// <summary>
        /// ShippingZipcode
        /// </summary>
        [MaxLength(250)]
        public string ShippingZipcode { get; set; }

        /// <summary>
        /// ShippingPhone
        /// </summary>
        [MaxLength(250)]
        public string ShippingPhone { get; set; }

        /// <summary>
        /// ShippingEmail
        /// </summary>
        [MaxLength(250)]
        public string ShippingEmail { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        [MaxLength(250)]
        public string Fax { get; set; }

        /// <summary>
        /// ShippedOnUtc
        /// </summary>
        public DateTime? ShippedOnUtc { get; set; }

        /// <summary>
        /// IsShipped
        /// </summary>
        public bool IsShipped { get; set; }

    }

    public enum CancelTypes
    {
        CancelledWithCharge = 1,
        CancelledWithOutCharge = 2
    }
}