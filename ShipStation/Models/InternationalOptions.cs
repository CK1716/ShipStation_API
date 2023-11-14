using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class InternationalOptions
    {
        public InternationalOptions() 
        {
            Contents = string.Empty;
            CustomsItems = null;
            NonDelivery = string.Empty;
        }
        public InternationalOptions(string _contents, CustomsItems _customsItems, string _nonDelivery)
        {
            Contents = _contents;
            CustomsItems = _customsItems;
            NonDelivery = _nonDelivery;
        }

        public string Contents { get; set; }
        public CustomsItems CustomsItems { get; set; }
        public string NonDelivery { get; set; }
    }
}
