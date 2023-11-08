using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class ItemOption
    {
        public ItemOption()
        {
            Name = string.Empty;
            Value = string.Empty;
        }
        public ItemOption(string _name, string _value)
        {
            Name = _name;
            Value = _value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
