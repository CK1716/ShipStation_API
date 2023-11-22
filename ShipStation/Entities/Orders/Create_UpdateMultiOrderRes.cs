using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShipStation.Models;

namespace ShipStation.Entities
{
    public class Create_UpdateMultiOrderResponse
    {

        public Create_UpdateMultiOrderResponse()
        {
            HasError = null;
            Results = null;
        }
        public Create_UpdateMultiOrderResponse(bool? _hasError, List<MultiOrdersResponseResults> _results)
        {
            HasError = _hasError;
            Results = _results;
        }

        public bool? HasError { get; set; }
        public List<MultiOrdersResponseResults> Results { get; set; } 

    }
}