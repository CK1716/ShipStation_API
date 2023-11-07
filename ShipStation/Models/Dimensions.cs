using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class Dimensions
    {
        public Dimensions(int? _length, int? _wight, int? _height, string _units)
        {
            Length = _length;
            Wight = _wight;
            Height = _height;
            Units = _units;
        }

        public int? Length { get; set; }
        public int? Wight { get; set; }
        public int? Height { get; set; }
        public string Units { get; set; }
    }
}
