using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Models;

namespace ShipStation.Entities.Orders
{
    public class Create_UpdateOrderReq
    {
        public Create_UpdateOrderReq()
        {
            OrderId = null;
            OrderNumber = string.Empty;
            OrderKey = string.Empty;
            OrderDate = null;
            PaymentDate = null;
            ShipByDate = null;
            OrderStatus = string.Empty;
            CustomerUsername = string.Empty;
            CustomerEmail = string.Empty;
            BillTo = null;
            ShipTo=null;
            Items = null;
            AmountPaid = null;
            TaxAmount = null;
            ShippingAmount = null;
            CustomerNotes = string.Empty;
            InternalNotes = string.Empty;
            Gift = null;
            GiftMessage = string.Empty;
            PaymentMethod = string.Empty;
            RequestedShippingService = string.Empty;
            CarrierCode = string.Empty;
            ServiceCode = string.Empty;
            PackageCode = string.Empty;
            Confirmation = string.Empty;
            ShipDate = null;
            Weight = null;
            Dimensions = null;
            InsuranceOptions = null;
            InternationalOptions = null;
            CustomsCountryCode = string.Empty;
            AdvancedOptions = null;
            TagIds = null;  
        }
        public Create_UpdateOrderReq(int? _orderId, string _orderNumber, string _orderKey, DateTime? _orderDate, DateTime? _paymentDate, DateTime? _shipByDate, string _orderStatus,
            string _customerUsername, string _customerEmail, Address _billTo, Address _shipTo, List<OrderItem> _items, int? _amountPaid, int? _taxAmount, int? _shippingAmount, string _customerNotes,
            string _internalNotes, bool? _gift, string _giftMessage, string _paymentMethod, string _requestedShippingService, string _carrierCode, string _serviceCode,
            string _packageCode, string _confirmation, DateTime? _shipDate, Weight _weight, Dimensions _dimensions, InsuranceOptions _insuranceOptions, InternationalOptions _internationalOptions,
            string _customsCountryCode, AdvancedOptions _advancedOptions, List<int?> _tagIds)
        {
            OrderId = _orderId;
            OrderNumber = _orderNumber;
            OrderKey = _orderKey;
            OrderDate = _orderDate;
            PaymentDate = _paymentDate;
            ShipByDate = _shipByDate;
            OrderStatus = _orderStatus;
            CustomerUsername = _customerUsername;
            CustomerEmail = _customerEmail;
            BillTo = _billTo;
            ShipTo = _shipTo;
            Items = _items;
            AmountPaid = _amountPaid;
            TaxAmount = _taxAmount;
            ShippingAmount = _shippingAmount;
            CustomerNotes = _customerNotes;
            InternalNotes = _internalNotes;
            Gift = _gift;
            GiftMessage = _giftMessage;
            PaymentMethod = _paymentMethod;
            RequestedShippingService = _requestedShippingService;
            CarrierCode = _carrierCode;
            ServiceCode = _serviceCode;
            PackageCode = _packageCode;
            Confirmation = _confirmation;
            ShipDate = _shipDate;
            Weight = _weight;
            Dimensions = _dimensions;
            InsuranceOptions = _insuranceOptions;
            InternationalOptions = _internationalOptions;
            CustomsCountryCode = _customsCountryCode;
            AdvancedOptions = _advancedOptions;
            TagIds = _tagIds;
        }

        public int? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderKey { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? PaymentDate { get; set;}
        public DateTime? ShipByDate { get; set; }
        public string OrderStatus { get; set; }
        public string CustomerUsername { get; set; }
        public string CustomerEmail { get; set; }   
        public Address BillTo { get; set; }
        public Address ShipTo { get; set; }
        public List<OrderItem> Items { get; set; }
        public int? AmountPaid { get; set; }
        public int? TaxAmount { get; set; }
        public int? ShippingAmount { get; set; }
        public string CustomerNotes { get; set; }
        public string InternalNotes { get; set; }
        public bool? Gift { get; set; }
        public string GiftMessage { get; set; }
        public string PaymentMethod { get; set; }
        public string RequestedShippingService { get; set; }
        public string CarrierCode { get; set; }
        public string ServiceCode { get; set; }
        public string PackageCode { get; set; }
        public string Confirmation { get; set; }
        public DateTime? ShipDate { get; set; }
        public Weight Weight { get; set; }
        public Dimensions Dimensions { get; set; }
        public InsuranceOptions InsuranceOptions { get; set; }
        public InternationalOptions InternationalOptions { get; set; }
        public string CustomsCountryCode { get; set; }
        public AdvancedOptions AdvancedOptions { get; set; }
        public List<int?> TagIds { get; set; }
    }
}
