using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class MultiOrdersResponseResults
    {
        public MultiOrdersResponseResults()
        {
            OrderId = null;
            OrderNumber = string.Empty;
            OrderKey = string.Empty;
            Success = null;
            ErrorMessage = string.Empty;
        }
       public MultiOrdersResponseResults (int? _orderId, string _orderNumber, string _orderKey, bool? _success, string _errorMessage)
        {
            OrderId = _orderId;
            OrderNumber = _orderNumber;
            OrderKey = _orderKey;
            Success = _success;
            ErrorMessage = _errorMessage;
        }

        public int? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderKey { get; set; }
        public bool? Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
