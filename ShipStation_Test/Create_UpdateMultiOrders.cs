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
    public class Create_UpdateMultiOrders
    {
        static void Create_UpdateMultiOrder(string[] args)
        {
            // Create obj : billTo
            Address objBillTo = new Address(
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
                _addressVerified:null);
            // Create obj : shipTo
            Address objShipTo = new Address(
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
                _addressVerified: null);
            
            // Create list : itemsOptions
            List<ItemOption> itemsOptionArr01 = new List<ItemOption>();
            ItemOption itemOption01 = new ItemOption(
                _name: "Size",
                _value: "Large");

            List<ItemOption> itemsOptionArr02 = new List<ItemOption>();
            ItemOption itemOption02 = new ItemOption(
                _name: null,
                _value: null);

            itemsOptionArr01.Add(itemOption01);
            itemsOptionArr02.Add(itemOption02);
            
            //Create list : items
            List<OrderItem> itemsArr = new List<OrderItem>();
            OrderItem objItems01 = new OrderItem(
                _orderItemId: null,
                _lineItemKey: "vd08-MSLbtx",
                _sku: "ABC123",
                _name: "Test item #1",
                _imageUrl: null,
                _weight: new Weight(
                    _value: 24,
                    _units: "ounces",
                    _weightUnits: null),
                _quantity: 2,
                _unitPrice: 99.99,
                _taxAmount: 2.5,
                _shippingAmount: 5,
                _warehouseLocation: "Aisle 1, Bin 7",
                _option: itemsOptionArr01,
                _productId: 123456,
                _fulfillmentSku: null,
                _adjustment: false,
                _upc: "32-65-98",
                _createDate: null,
                _modifyDate: null);

            OrderItem objItems02 = new OrderItem(
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
                _option: itemsOptionArr02,
                _productId: 123456,
                _fulfillmentSku: "SKU-Discount",
                _adjustment: true,
                _upc: null,
                _createDate: null,
                _modifyDate: null);

            itemsArr.Add(objItems01);
            itemsArr.Add(objItems02);

            List<Order> order = new List<Order>();
            Order order01 = new Order(
                _orderId: null,
                _orderNumber: "TEST-ORDER-API-DOCS-01",
                _orderKey: "0f6bec18-3e89-4881-83aa-f392d84f4c74",
                _orderDate: DateTime.Parse("2015-06-29T08:46:27.0000000"),
                _createDate: null,
                _modifyDate: null,
                _paymentDate: DateTime.Parse("2015-06-29T08:46:27.0000000"),
                _shipByDate: DateTime.Parse("2015-07-05T00:00:00.0000000"),
                _orderStatus: "awaiting_shipment",
                _customerId: 37701499,
                _customerUsername: "headhoncho@whitehouse.gov",
                _customerEmail: "headhoncho@whitehouse.gov",
                _billTo: objBillTo,
                _shipTo: objShipTo,
                _items: itemsArr,
                _orderTotal: null,
                _amountPaid: 218.73,
                _taxAmount: 5,
                _shippingAmount: 10,
                _customerNotes: "Please ship as soon as possible!",
                _internalNotes: "Customer called and would like to upgrade shipping",
                _gift: true,
                _giftMessage: "Thank you!",
                _paymentMethod: "Credit Card",
                _requestedShippingService: "Priority Mail",
                _carrierCode: "fedex",
                _serviceCode: "fedex_2day",
                _packageCode: "package",
                _confirmation: "delivery",
                _shipDate: DateTime.Parse("2015-07-02"),
                _holdUntilDate: null,
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
                _advancedOptions: new AdvancedOptions(
                    _warehouseId: null,
                    _nonMachinable: false,
                    _saturdayDelivery: false,
                    _containsAlcohol: false,
                    _mergedOrSplit: false,
                    _mergedIds: new List<int?>(),
                    _parentId: null,
                    _storeId: null,
                    _customField1: "Custom data that you can add to an order. See Custom Fields #2 & #3 for more info!",
                    _customField2: "Per UI settings, this information can appear on some carriers' shipping labels. See the link below",
                    _customField3: "https://help.shipstation.com/hc/en-us/articles/206639957",
                    _source: "Webstore",
                    _billToParty: null,
                    _billToAccount: null,
                    _billToPostalCode: null,
                    _billToCountryCode: null,
                    _billToMyOtherAcoount: null),
                _tagIds: new List<int?> { 53974 },
                _userId: null,
                _externallyFulfilled: null,
                _externallyFulfilledBy: null);

            order.Add(order01);

            Order order02 = new Order(
                _orderId: null,
                _orderNumber: "TEST-ORDER-API-DOCS-02",
                _orderKey: "0d6bec18-3e79-4981-83ca-f392d84f4c19",
                _orderDate: DateTime.Parse("2015-06-29T08:46:27.0000000"),
                _createDate: null,
                _modifyDate: null,
                _paymentDate: DateTime.Parse("2015-06-29T08:46:27.0000000"),
                _shipByDate: DateTime.Parse("2015-07-05T00:00:00.0000000"),
                _orderStatus: "awaiting_shipment",
                _customerId: 37701499,
                _customerUsername: "headhoncho@whitehouse.gov",
                _customerEmail: "headhoncho@whitehouse.gov",
                _billTo: objBillTo,
                _shipTo: objShipTo,
                _items: itemsArr,
                _orderTotal: null,
                _amountPaid: 218.73,
                _taxAmount: 5,
                _shippingAmount: 10,
                _customerNotes: "Please ship as soon as possible!",
                _internalNotes: "Customer called and would like to upgrade shipping",
                _gift: null,
                _giftMessage: "Thank you",
                _paymentMethod: "Credit Card",
                _requestedShippingService: "Priority Mail",
                _carrierCode: "fedex",
                _serviceCode: "fedex_2day",
                _packageCode: "package",
                _confirmation: "delivery",
                _shipDate: DateTime.Parse("2015-07-02"),
                _holdUntilDate: null,
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
                _tagIds: new List<int?> { 53974 },
                _userId: null,
                _externallyFulfilled: false,
                _externallyFulfilledBy: null);

            order.Add(order02);

            Create_UpdateMultiOrderRequest createUpdateMultiOrderReq = new Create_UpdateMultiOrderRequest(_orders: order);
            Create_UpdateMultiOrderResponse resDate = API_Orders.CreateUpdateMultiOrder(createUpdateMultiOrderReq);

        }
    }
}
