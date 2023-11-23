using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Entities
{
    public class MarkShippedRequest
    {
        public MarkShippedRequest()
        {
            OrderId = null;
            CarrierCode = string.Empty;
            ShipDate = string.Empty;    
            TrackingNumber = string.Empty;
            NotifyCustomer = null;
            NotifySalesChannel = null;
        }

        public MarkShippedRequest(int? _orderId, string _carrierCode, string _shipDate, string _trackingNumber, bool? _notifyCustomer, bool? _notifySalesChannel)
        {
            OrderId = _orderId;
            CarrierCode = _carrierCode;
            ShipDate = _shipDate;
            TrackingNumber = _trackingNumber;
            NotifyCustomer = _notifyCustomer;
            NotifySalesChannel = _notifySalesChannel;
        }

        public int? OrderId { get; set; }
        public string CarrierCode { get; set; }
        public string ShipDate { get; set; }
        public string TrackingNumber { get; set; }
        public bool? NotifyCustomer { get; set; }
        public bool? NotifySalesChannel { get; set; }
    }
}
