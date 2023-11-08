using ShipStation.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Models;

namespace ShipStation_Test
{
    public class Create_UpdateOrders
    {
        static void Main(string[] args)
        {
            Create_UpdateOrderReq create_updateOrders = new Create_UpdateOrderReq(
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
                //Json안에 List값 초기화 시키는 법 찾기! Line 53 - 76
/*                _items: new List<OrderItem>(new OrderItem( 
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
                    _modifyDate: null)),*/
                
                    // _amountPaid: 218.73, 
                    // ...
                
                    
                
                
                    
        }

    }
}
