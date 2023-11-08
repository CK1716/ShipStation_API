using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Models;

namespace ShipStation.Entities
{
    public class CreateLabelForOrderRequest
    {
        public CreateLabelForOrderRequest() { }
        public CreateLabelForOrderRequest(int? _orderId, string _carrierCode, string _serviceCode, string _packageCode, string _confirmation, DateTime? _shipDate,
            Weight _weight, Dimensions _dimensions, InsuranceOptions _insuranceOptions, InternationalOptions _internationalOptions, AdvancedOptions _advancedOptions,
            bool? _testLabel)
        {
            OrderID = _orderId;
            CarrierCode = _carrierCode;
            ServiceCode = _serviceCode;
            PackageCode = _packageCode;
            Confirmation = _confirmation;
            ShipDate = _shipDate;
            Weight = _weight;
            Dimensions = _dimensions;
            InsuranceOptions = _insuranceOptions;
            InternationalOptions = _internationalOptions;
            AdvancedOptions = _advancedOptions;
            TestLabel = _testLabel;
        }


        public int? OrderID { get; set; }
        public string CarrierCode { get; set; }
        public string ServiceCode { get; set; }
        public string PackageCode { get; set; }
        public string Confirmation { get; set; }
        public DateTime? ShipDate { get; set; }
        public Weight Weight { get; set; }
        public Dimensions Dimensions { get; set; }
        public InsuranceOptions InsuranceOptions { get; set; }
        public InternationalOptions InternationalOptions { get; set; }
        public AdvancedOptions AdvancedOptions { get; set; }
        public bool? TestLabel { get; set; }
    }
}
