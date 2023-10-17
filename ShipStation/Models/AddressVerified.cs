using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Models
{
    public class AddressVerified
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum _value
        {
            [EnumMember(Value = "Address not yet validated")]
            NotVerified = 0,

            [EnumMember(Value = "Address validation warning")]
            Warning = 1,

            [EnumMember(Value = "Address validation failed")]
            Failed = 2,

            [EnumMember(Value = "Address validated successfully")]
            Successful = 3
        }
    }
}
