using ShipStation.Api;
using ShipStation.Entities;
using ShipStation.Enums;
using ShipStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation_Test
{
    public class Fulfillments
    {
        public static void Fulfillment(String[] args)
        {
            FulfillmentRequest fulfillmentsReq = new FulfillmentRequest(
                _fulfillmentId : 33974374,
                _orderId: 191759016,
                _orderNumber: "101",
                _trackingNumber: "783408231234",
                _recipientName: null,
                _createDateStart: DateTime.Parse("2016-06-07T08:50:50.0670000"),
                _createDateEnd: DateTime.Parse("2016-06-07T23:50:50.0670000"),
                _shipDateStart: DateTime.Parse("2016-06-07T00:00:00.0000000"),
                _shipDateEnd: DateTime.Parse("2016-06-07T00:00:00.0000000"),
                _sortBy: FulfillmentsSortBy.CreateDate,
                _sortDir: SortDir.Ascending,
                _page: 1,
                _pageSize: 0);

            FulfillmentResponse resData = API_Fulfillments.ListFulfillments(fulfillmentsReq);
        }
    }
}
