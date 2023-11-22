using ShipStation.Api;
using ShipStation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation_Test
{
    public class HoldOrders
    {
        static void Main(string[] args)
        {
            HoldOrderRequest holdOrdersReq = new HoldOrderRequest(
                _orderId: 1072467,
                _holdUntilDate: DateTime.Parse("2014-12-01"));

            HoldOrderResponse resDate = API_Orders.HoldOrders(holdOrdersReq);

        }
    }
}
