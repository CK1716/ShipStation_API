using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ShipStation.Models;

using ShipStation.Enums;

namespace ShipStation.Entities
{
    public class FulfillmentRequest
    {
        public FulfillmentRequest(int _fulfillmentId, int _orderId, string _orderNumber, string _trackingNumber,
            string _recipientName, DateTime _createDateStart, DateTime _createDateEnd, DateTime _shipDateStart,
            DateTime _shipDateEnd, FulfillmentsSortBy _sortBy, SortDir _sortDir, int _page, int _pageSize)
        {
            FulfillmentId = _fulfillmentId;
            OrderId = _orderId;
            OrderNumber = _orderNumber;
            TrackingNumber = _trackingNumber;
            RecipientName = _recipientName;
            CreateDateStart = _createDateStart;
            CreateDateEnd = _createDateEnd;
            ShipDateStart = _shipDateStart;
            ShipDateEnd = _shipDateEnd;

            SortBy = _sortBy;   
            if(_sortBy.Equals("")) { SortBy = FulfillmentsSortBy.CreateDate; }

            SortDir = _sortDir;
            Page = _page;
            PageSize = _pageSize;
        }
        public int? FulfillmentId { get; set; }
        public int? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string RecipientName { get; set; }
        public DateTime? CreateDateStart { get; set; }
        public DateTime? CreateDateEnd { get; set; }
        public DateTime? ShipDateStart { get; set; }
        public DateTime? ShipDateEnd { get; set; }
        public FulfillmentsSortBy SortBy { get; set; }
        public SortDir SortDir { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
