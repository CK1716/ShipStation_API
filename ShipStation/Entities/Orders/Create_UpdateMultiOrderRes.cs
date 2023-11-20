using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Entities
{
    public class Create_UpdateMultiOrderResponse
    {

        public Create_UpdateMultiOrderResponse()
        {
            HasError = null;
            OrderId = null;
            OrderNumber = string.Empty;
            OrderKey = string.Empty;
            Success = null;
            ErrorMessage = string.Empty;
        }
        public Create_UpdateMultiOrderResponse(bool? _hasError, int? _orderId, string _orderNumber, string _orderKey, bool? _success, string _errorMessage)
        {
            HasError = _hasError;
            OrderId = _orderId;
            OrderNumber = _orderNumber;
            OrderKey = _orderKey;
            Success = _success;
            ErrorMessage = _errorMessage;
        }

        public bool? HasError { get; set; }
        public int? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderKey { get; set; }
        public bool? Success { get; set; }
        public string ErrorMessage {  get; set; }

    }
}