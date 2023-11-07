using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public  class Weight
    {
        public Weight() { }
        public Weight(int? _value, string _units, int? _weightUnits)
        {
            Value = _value;
            Units = _units;
            WeightUnits = _weightUnits;
        }

        public int? Value { get; set; }
        public string Units { get; set; }
        public int? WeightUnits { get; set; }
    }
}
