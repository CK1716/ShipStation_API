using Newtonsoft.Json.Linq;
using ShipStation.Api;
using ShipStation.Entities;
using ShipStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ShipStation_Test
{
    public class CreateLabelForOrders
    {
        static void Main(string[] args)
        {
            /*CreateLabelForOrderRequest createLabelForOrderReq = new CreateLabelForOrderRequest()
            {
                OrderID = 93348442,
                CarrierCode = "fedex",
                ServiceCode = "fedex_2day",
                PackageCode = "package",
                Confirmation = null,
                ShipDate = DateTime.Parse("2014 - 04 - 03"),
                Weight = new Weight(
                    _value: 2,
                    _units: "pounds",
                    _weightUnits: null),
                Dimensions = null,
                InsuranceOptions = null,
                InternationalOptions = null,
                AdvancedOptions = null,
                TestLabel = false
            };*/

            CreateLabelForOrderRequest createLabelForOrderReq = new CreateLabelForOrderRequest(
                _orderId: 93348442,
                _carrierCode: "fedex",
                _serviceCode: "fedex_2day",
                _packageCode: "package",
                _confirmation: null,
                _shipDate: DateTime.Parse("2014 - 04 - 03"),
                _weight: new Weight(
                    _value: 2,
                    _units: "pounds",
                    _weightUnits: null),
                _dimensions: null,
                _insuranceOptions: null,
                _internationalOptions: null,
                _advancedOptions: null,
                _testLabel: false
                );
            


            CreateLabelForOrderResponse createLabelForOrderRes = CreateLabelForOrder.ClReq(createLabelForOrderReq);
        }
    }
}
