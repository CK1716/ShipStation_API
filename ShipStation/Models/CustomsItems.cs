using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class CustomsItems
    {
        public CustomsItems() 
        {
            CustomsItemsId = string.Empty;
            Description = string.Empty;
            Quantity = null;
            Value = null;
            HarmonizedTariffCode = string.Empty;
            CountryOfOrigin = string.Empty;
        }
        public CustomsItems(string _customsItemsId, string _description, int? _quantity, int? _value, 
            string _harmonizedTariffCode, string _countryOfOrigin)
        {
            CustomsItemsId = _customsItemsId;
            Description = _description;
            Quantity = _quantity;
            Value = _value;
            HarmonizedTariffCode = _harmonizedTariffCode;
            CountryOfOrigin = _countryOfOrigin;
        }

        public string CustomsItemsId { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int? Value { get; set; }
        public string HarmonizedTariffCode { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
