using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class Dimensions
    {
        public Dimensions() 
        {
            Length = null;
            Width = null;
            Height = null;
            Units = string.Empty;
        }
        public Dimensions(int? _length, int? _width, int? _height, string _units)
        {
            Length = _length;
            Width = _width;
            Height = _height;
            Units = _units;
        }

        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Units { get; set; }
    }
}
