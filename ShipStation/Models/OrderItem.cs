using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
            OrderItemId = null;
            LineItemKey = string.Empty;
            Sku = string.Empty;
            Name = string.Empty;
            ImageUrl = string.Empty;
            Weight = null;
            Quantity = null;
            UnitPrice = null;
            TaxAmount = null;
            ShippingAmount = null;
            WarehouseLocation = string.Empty;
            Options = null;
            ProductId = null;
            FulfillmentSku = string.Empty;
            Adjustment = null;
            Upc = string.Empty;
            CreateDate = null;
            ModifyDate = null;
        }
        public OrderItem(int? _orderItemId, string _lineItemKey, string _sku, string _name, string _imageUrl, Weight _weight,
            int _quantity, double? _unitPrice, double? _taxAmount, int? _shippingAmount, string _warehouseLocation, List<ItemOption> _option,
            int _productId, string _fulfillmentSku, bool _adjustment, string _upc, DateTime? _createDate, DateTime? _modifyDate)
        {
            OrderItemId = _orderItemId;
            LineItemKey = _lineItemKey;
            Sku = _sku;
            Name = _name;
            ImageUrl = _imageUrl;
            Weight = _weight;
            Quantity = _quantity;
            UnitPrice = _unitPrice;
            TaxAmount = _taxAmount;
            ShippingAmount = _shippingAmount;
            WarehouseLocation = _warehouseLocation;
            Options = _option;
            ProductId = _productId;
            FulfillmentSku = _fulfillmentSku;
            Adjustment = _adjustment;
            Upc = _upc;
            CreateDate = _createDate;
            ModifyDate = _modifyDate;
        }

        public int? OrderItemId { get; set; }
        public string LineItemKey { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Weight Weight { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public double? TaxAmount { get; set; }
        public int? ShippingAmount { get; set; }
        public string WarehouseLocation { get; set; }
        public List<ItemOption> Options { get; set; }
        public int? ProductId { get; set; }
        public string FulfillmentSku { get; set; }
        public bool? Adjustment { get; set; }
        public string Upc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
