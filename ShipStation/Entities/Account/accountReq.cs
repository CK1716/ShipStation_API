using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipStation.Entities
{
    public class AccountRequest
    {
        public AccountRequest(string _firstName, string _lastName, string _email, string _password,
            string _shippingOriginCountryCode, string _company, string _addr1, string _addr2, string _city,
            string _state, string _zip, string _countryCode, string _phone)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Email = _email;
            Password = _password;
            ShippingOriginCountryCode = _shippingOriginCountryCode;
            CompanyName = _company;
            Addr1 = _addr1;
            Addr2 = _addr2;
            City = _city;
            State = _state;
            Zip = _zip;
            CountryCode = _countryCode;
            Phone = _phone;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ShippingOriginCountryCode { get; set; }
        public string CompanyName { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
    }
}