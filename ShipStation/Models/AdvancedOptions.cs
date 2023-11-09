using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class AdvancedOptions
    {
        public AdvancedOptions(int? _warehouseId, bool? _nonMachinable, bool? _saturdayDelivery, bool? _containsAlcohol, int? _storeId,
            string _customField1, string _customField2, string _customField3, string _source, bool? _mergedOrSplit, List<int> _mergedIds,
            int? _parentId, string _billToParty, string _billToAccount, string _billToPostalCode, string _billToCountryCode, string _billToMyOtherAcoount)
        {
            WarehouseId = _warehouseId;
            NonMachinable = _nonMachinable;
            SaturdayDelivery = _saturdayDelivery;
            ContainsAlcohol = _containsAlcohol;
            StoreId = _storeId;
            CustomField1 = _customField1;
            CustomField2 = _customField2;
            CustomField3 = _customField3;
            Source = _source;
            MergedOrSplit = _mergedOrSplit;
            MergedIds = _mergedIds;
            ParentId = _parentId;
            BillToParty = _billToParty;
            BillToAccount = _billToAccount;
            BillToPostalCode = _billToPostalCode;
            BillToCountryCode = _billToCountryCode;
            BillToMyOtherAccount = _billToMyOtherAcoount;
        }

        public int? WarehouseId { get; set; }
        public bool? NonMachinable { get; set; }
        public bool? SaturdayDelivery { get; set; }
        public bool? ContainsAlcohol { get; set; }
        public int? StoreId { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string CustomField3 { get; set; }
        public string Source { get; set; }
        public bool? MergedOrSplit { get; set; }
        public List<int> MergedIds { get; set; }
        public int? ParentId { get; set; }
        public string BillToParty { get; set; } 
        public string BillToAccount { get; set; }
        public string BillToPostalCode { get; set; }
        public string BillToCountryCode { get; set; }   
        public string BillToMyOtherAccount { get; set; }

    }
}
