using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class InsuranceOptions
    {
        public InsuranceOptions() 
        {
            Provider = string.Empty;
            InsureShipment = null;
            InsuredValue = null;
        }
        public InsuranceOptions(string _provider, bool? _insureShipment, int? _insuredValue)
        {
            Provider = _provider;
            InsureShipment = _insureShipment;
            InsuredValue = _insuredValue;
        }

        public string Provider { get; set; }
        public bool? InsureShipment { get; set; }
        public int? InsuredValue { get; set; }
    }
}
