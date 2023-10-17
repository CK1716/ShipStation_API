using ShipStation.Entities;
using ShipStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShipStation_Test
{
    public class Fulfillments
    {
        public static void fulfillments(String[] args)
        {
            /* sortBy, sortDir 형 변환 하는 법?? 
             * enum 사용 <- 관련해서 찾아보면 될 듯..?
             * 없으면 get set에서 정렬..? */

            FulfillmentRequest fulfillmentReq = new FulfillmentRequest(
                _fulfillmentId : 123,
                _orderId: 123,
                _orderNumber: "",
                _trackingNumber: "",
                _recipientName: "",
                _createDateStart: DateTime.Parse("2023-10-17"),
                _createDateEnd: DateTime.Parse("2023-10-17"),
                _shipDateStart: DateTime.Parse("2023-10-17"),
                _shipDateEnd: DateTime.Parse("2023-10-17"),
                _sortBy: null,
                _sortDir: null,
                _page: 1,
                _pageSize: 100);


        }
    }
}
