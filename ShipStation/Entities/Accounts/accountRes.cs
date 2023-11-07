using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Entities

{
    public class AccountResponse
    {
        /* 모델 사용 x
        public AccountResponse() { } */
        public AccountResponse(string _message, int _sellerId, bool _success, string _apiKey, string _apiSecret) 
        {
            Message = _message;
            SellerId = _sellerId;
            Success = _success;
            ApiKey = _apiKey;
            ApiSecret = _apiSecret;
        }
        public string Message { get; set; }
        public int SellerId { get; set; }
        public bool Success { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

    }
}