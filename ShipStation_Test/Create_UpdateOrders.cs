using ShipStation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Models;
using ShipStation.Api;

namespace ShipStation_Test
{
    public class Create_UpdateOrders
    {
        static void Main(string[] args)
        {
            List<OrderItem> itemList = new List<OrderItem>();
            OrderItem item01 = new OrderItem(
                _orderItemId: null,
                    _lineItemKey: "vd08-MSLbtx",
                    _sku: "ABC123",
                    _name: "Test item #1",
                    _imageUrl: null, // imageUrl == image
                    _weight: new Weight(
                        _value: 24,
                        _units: "ounces",
                        _weightUnits: null),
                    _quantity: 2,
                    _unitPrice: 99.99,
                    _taxAmount: 2.5,
                    _shippingAmount: 5,
                    _warehouseLocation: "Aisle 1, Bin 7",
                    _option: new ItemOption(
                        _name: "Size",
                        _value: "Large"),
                    _productId: 123456,
                    _fulfillmentSku: null,
                    _adjustment: false,
                    _upc: "32-65-98",
                    _createDate: null,
                    _modifyDate: null);

            OrderItem item02 = new OrderItem(
                 _orderItemId: null,
                        _lineItemKey: null,
                        _sku: "DISCOUNT CODE",
                        _name: "10% OFF",
                        _imageUrl: null,
                        _weight: new Weight(
                            _value: 0,
                            _units: "ounces",
                            _weightUnits: null),
                        _quantity: 1,
                        _unitPrice: -20.55,
                        _taxAmount: null,
                        _shippingAmount: null,
                        _warehouseLocation: null,
                        _option: new ItemOption(
                            _name: null,
                            _value: null),
                        _productId: 123456,
                        _fulfillmentSku: "SKU-Discount",
                        _adjustment: true,
                        _upc: null,
                        _createDate: null,
                        _modifyDate: null
                );

            itemList.Add(item01);
            itemList.Add(item02);

            Create_UpdateOrderRequest create_updateOrderReq = new Create_UpdateOrderRequest(
                _orderId: 37701499, // orderId == customerId
                _orderNumber: "TEST-ORDER-API-DOCS",
                _orderKey: "0f6bec18-3e89-4881-83aa-f392d84f4c74",
                _orderDate: DateTime.Parse("2015-06-29T08:46:27.0000000"),
                _paymentDate: DateTime.Parse("2015-06-29T08:46:27.0000000"),
                _shipByDate: DateTime.Parse("2015-07-05T00:00:00.0000000"),
                _orderStatus: "awaiting_shipment",
                _customerUsername: "headhoncho@whitehouse.gov",
                _customerEmail: "headhoncho@whitehouse.gov",
                _billTo: new Address(
                    _name: "The President",
                    _company: null,
                    _street1: null,
                    _street2: null,
                    _street3: null,
                    _city: null,
                    _state: null,
                    _postalCode: null,
                    _country: null,
                    _phone: null,
                    _isResidential: null,
                    _addressVerified: null),
                _shipTo: new Address(
                    _name: "The President",
                    _company: "US Govt",
                    _street1: "1600 Pennsylvania Ave",
                    _street2: "Oval Office",
                    _street3: null,
                    _city: "Washington",
                    _state: "DC",
                    _postalCode: "20500",
                    _country: "US",
                    _phone: "555-555-5555",
                    _isResidential: true,
                    _addressVerified: null),
                _items: new List<OrderItem>(
                   itemList),
                    _amountPaid: 218.73,
                    _taxAmount: 5,
                    _shippingAmount: 10,
                    _customerNotes: "Please ship as soon possible",
                    _internalNotes: "Customer called and would like to upgrade shipping",
                    _gift: null,
                    _giftMessage: "Thank you!",
                    _paymentMethod: "Credit Card",
                    _requestedShippingService: "Priority Mail",
                    _carrierCode: "fedex",
                    _serviceCode: "fedex_2day",
                    _packageCode: "package",
                    _confirmation: "delivery",
                    _shipDate: DateTime.Parse("2015-07-02"),
                    _weight: new Weight(
                        _value: 25,
                        _units: "ounces",
                        _weightUnits: null),
                    _dimensions: new Dimensions(
                        _units: "inches",
                        _length: 7,
                        _width: 5,
                        _height: 6),
                    _insuranceOptions: new InsuranceOptions(
                        _provider: "carrier",
                        _insureShipment: true,
                        _insuredValue: 200),
                    _internationalOptions: new InternationalOptions(
                        _contents: null,
                        _customsItems: null,
                        _nonDelivery: null),
                    _customsCountryCode: null,
                    _advancedOptions: new AdvancedOptions(
                        _warehouseId: null,
                        _nonMachinable: false,
                        _saturdayDelivery: false,
                        _containsAlcohol: false,
                        _mergedOrSplit: false,
                        _mergedIds: new List<int?>(),
                        _parentId: null,
                        _storeId: null,
                        _customField1: "Custom data that you can add to an order. See Custom Field #2 & #3 for more info!",
                        _customField2: "Per UI settings, this information can appear on some carrier's shipping labels. See link below",
                        _customField3: "https://help.shipstation.com/hc/en-us/articles/206639957",
                        _source: "Webstore",
                        _billToParty: null,
                        _billToAccount: null,
                        _billToPostalCode: null,
                        _billToCountryCode: null,
                        _billToMyOtherAcoount: null),
                    _tagIds: new List<int?> { 53974 });

            Create_UpdateOrderResponse resData = CreateUpdateOrder.CuOrder(create_updateOrderReq);
        }

    }
}
