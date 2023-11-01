using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Json;

namespace ShipStation.Models
{
    public class Address
    {
        public Address() { }
        public Address(string _name, string _company, string _street1, string _street2, string _street3, string _city,
            string _state, string _postalCode, string _country, string _phone, bool _isResidential, string _addressVerified)
        {
            Name = _name;
            Company = _company;
            Street1 = _street1;
            Street2 = _street2;
            Street3 = _street3;
            City = _city;
            State = _state;
            PostalCode = _postalCode;
            Country = _country;
            Phone = _phone;
            IsResidential = _isResidential;
            AddressVerified = _addressVerified;
        }

        public string Name { get; set; }
        public string Company { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public bool IsResidential { get; set; }
        public string AddressVerified { get; set; }
    }
}