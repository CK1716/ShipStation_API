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
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentsSortBy
    {
        [EnumMember(Value = "shipDate")]
        ShipDate = 0,

        [EnumMember(Value = "createDate")]
        CreateDate = 1
    }
}
