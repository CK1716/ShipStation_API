using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Entities
{
    public class CreateLabelForOrderResponse
    {
        public CreateLabelForOrderResponse(int? _shipmentId, double? shipmentCost, int? insuranceCost, string _trackingNumber,
            string _labelData, string _formData)
        {
            ShipmentId = _shipmentId;
            ShipmentCost = shipmentCost;
            InsuranceCost = insuranceCost;
            TrackingNumber = _trackingNumber;
            LabelData = _labelData;
            FormData = _formData;
        }

        public int? ShipmentId { get; set; }
        public double? ShipmentCost { get; set; }
        public int? InsuranceCost { get; set; }
        public string TrackingNumber { get; set; }
        public string LabelData { get; set; }
        public string FormData { get; set; }
    }
}
