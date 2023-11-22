using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Entities
{
    public class HoldOrderResponse
    {
        public HoldOrderResponse()
        {
            Success = null;
            Message = string.Empty;
        }

        public HoldOrderResponse(bool? _success, string _message)
        {
            Success = _success;
            Message = _message;
        }

        public bool? Success { get; set; }
        public string Message { get; set; }
    }
}
