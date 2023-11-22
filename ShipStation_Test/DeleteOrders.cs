using ShipStation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Api;

namespace ShipStation_Test
{
    public class DeleteOrders
    {
        static void DelectOrder(string[] args)
        {
            DeleteOrderRequest delectOrdersReq = new DeleteOrderRequest();
            DeleteOrderResponse resData = API_Orders.DeleteOrders(delectOrdersReq);
        }
    }
}
