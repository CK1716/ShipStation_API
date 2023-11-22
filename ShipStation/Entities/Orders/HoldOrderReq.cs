using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Entities
{
    public class HoldOrderRequest
    {
        public HoldOrderRequest()
        {
            OrderId = null;
            HoldUntilDate = null;
        }

        public HoldOrderRequest(int? _orderId, DateTime? _holdUntilDate)
        {
            OrderId = _orderId;
            HoldUntilDate = _holdUntilDate;
        }

        public int? OrderId { get; set; }
        public DateTime? HoldUntilDate { get; set; }
    }
}
