using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ShipStation.Models;

namespace ShipStation.Entities
{
    public class FulfillmentResponse
    {
        public FulfillmentResponse(int _fulfillmentId, int _orderId, string _orderNumber, string _userId, string _customerEmail,
            string _trackingNumber, DateTime _createDate, DateTime _shipDate, DateTime _voidDate, DateTime _deliveryDate,
            string _carrierCode, string _fulfillmentProviderCode, string _fulfillmentServiceCode, double _fulfillmentFee,
            bool _isVoidRequested, bool _isVoided, bool _isMarketpalceNotified, string _notifyErrorMessage, Address _shipTo)
        {
            FulfillmentId = _fulfillmentId;
            OrderId = _orderId;
            OrderNumber = _orderNumber;
            UserId = _userId;
            CustomerEmail = _customerEmail;
            TrackingNumber = _trackingNumber;
            CreatedDate = _createDate;
            ShipDate = _shipDate;
            VoidDate = _voidDate;
            DeliveryDate = _deliveryDate;
            CarrierCode = _carrierCode;
            FulfillmentProviderCode = _fulfillmentProviderCode;
            FulfillmentServiceCode = _fulfillmentServiceCode;
            FulfillmentFee = _fulfillmentFee;
            IsVoidRequested = _isVoidRequested;
            IsVoided = _isVoided;
            IsMarketplaceNotified = _isMarketpalceNotified;
            NotifyErrorMessage = _notifyErrorMessage;
            ShipTo = _shipTo;
        }
        public int? FulfillmentId { get; set; }
        public int? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string UserId { get; set; }
        public string CustomerEmail { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? VoidDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string CarrierCode { get; set; }
        public string FulfillmentProviderCode { get; set; }
        public string FulfillmentServiceCode { get; set; }
        public double? FulfillmentFee { get; set; }
        public bool? IsVoidRequested { get; set; }
        public bool? IsVoided { get; set; }
        public bool? IsMarketplaceNotified { get; set; }
        public string NotifyErrorMessage { get; set; }
        public Address ShipTo { get; set; }
    }
}
