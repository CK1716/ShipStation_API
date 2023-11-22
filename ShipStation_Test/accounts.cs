using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using System.Net.Json;
using Newtonsoft.Json;

using ShipStation.Api;
using ShipStation.Entities;

namespace ShipStation_Test
{
    public class Accounts
    {
        public static void Account(String[] args)
        {
            AccountRequest accountsReq = new AccountRequest(
                _firstName: "John",
                _lastName: "Smith",
                _email: "jsmithtest@gmail.com",
                _password: "testpw1234",
                _shippingOriginCountryCode: "US",
                _company: "Droid Repair LLC",
                _addr1: "542 Midichlorian Rd",
                _addr2: "",
                _city: "Austin",
                _state: "TX",
                _zip: "78709",
                _countryCode: "US",
                _phone: "5124111234");

            AccountResponse resData = API_Account.Register(accountsReq);
        }
    }
}