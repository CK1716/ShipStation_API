using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Models;

namespace ShipStation.Entities
{
    public class Create_UpdateMultiOrderReq
    { 
        public Create_UpdateMultiOrderReq()
        {
            Orders = null;
        }
        public Create_UpdateMultiOrderReq(List<Order> _orders)
        {
            Orders = _orders;
        }
        public List<Order> Orders { get; set; }
    }
}
