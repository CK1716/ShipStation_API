using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Models;

namespace ShipStation.Entities
{
    public class Create_UpdateOrderResponse
    {
        public Create_UpdateOrderResponse() 
        {
            OrderId = null;
            Number = string.Empty;
            OrderKey = string.Empty;
            OrderDate = null;
            CreateDate = null;
            ModifyDate = null;
            PaymentDate = null;
            ShipByDate = null;
            OrderStatus = string.Empty;
            CustomerId = null;
            CustomerUserName = string.Empty;
            CustomerEmail = string.Empty;
            BillTo = null;
            ShipTo = null;
            Items = null;
            OrderTotal = null;
            AmountTotal = null;
            TaxAmount = null;
            CustomerNotes = string.Empty;
            InternalNotes = string.Empty;
            Gift = null;
            GiftMessage = string.Empty;
            PayMentMethod = string.Empty;
            RequestedShippingService = string.Empty;
            CarrierCode = string.Empty;
            Service = string.Empty;
            PackageCode = string.Empty;
            Confirmation = string.Empty;
            ShipDate = null;
            HoldUntillDate = null;
            Weight = null;
            Dimensions = null;
            InsuranceOptions = null;
            InternationalOptions = null;
            AdvancedOptions = null;
            TagIds = null;
            UserId = null;
            ExternallyFulfilled = null;
            ExternallyFulfilledBy = string.Empty;
        }

        public int? OrderId { get; set; }
        public string Number { get; set; }
        public string OrderKey { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? PaymentDate { get; set;}
        public DateTime? ShipByDate { get; set; }
        public string OrderStatus { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerEmail { get; set; }
        public Address BillTo { get; set; }
        public Address ShipTo { get; set; }
        public List<OrderItem> Items { get; set; }
        public double? OrderTotal { get; set; }
        public double? AmountTotal { get; set; }
        public int? TaxAmount { get; set; }
        public string CustomerNotes { get; set; }
        public string InternalNotes { get; set; }
        public bool? Gift { get; set; }
        public string GiftMessage { get; set; } 
        public string PayMentMethod { get; set; }
        public string RequestedShippingService { get; set; }    
        public string CarrierCode { get; set; }
        public string Service { get; set; }
        public string PackageCode { get; set; } 
        public string Confirmation { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? HoldUntillDate { get; set; }
        public Weight Weight { get; set; }  
        public Dimensions Dimensions { get; set; }
        public InsuranceOptions InsuranceOptions { get; set; }  
        public InternationalOptions InternationalOptions { get; set; }
        public AdvancedOptions AdvancedOptions { get; set; }    
        public List<int?> TagIds { get; set; }
        public int? UserId { get; set; }    
        public bool? ExternallyFulfilled { get; set; }
        public string ExternallyFulfilledBy { get; set; }
    }
}
