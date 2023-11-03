using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Json;

namespace ShipStation.Models
{
    public class Address
    {
        /*static dynamic _value = null;*/
        public Address() {
            Name = string.Empty;
            Company = string.Empty;
            Street1 = string.Empty;
            Street2 = string.Empty;
            Street3 = string.Empty;
            City = string.Empty;
            State = string.Empty;
            PostalCode = string.Empty;  
            Country = string.Empty; 
            Phone = string.Empty;
            IsResidential = null;
            AddressVerified = null;

            /*switch(AddressVerified.Value)
            {
                case Models.AddressVerified.NotVerified:
                    // _value = "Address not yet validated";
                    AddressVerified = Models.AddressVerified.NotVerified;
                    break;

                case Models.AddressVerified.Warning:
                    _value = "Address validation warning";
                    AddressVerified = _value;
                    break;

                case Models.AddressVerified.Failed:
                    _value = "Address validation failed";
                    AddressVerified = _value;
                    break;

                case Models.AddressVerified.Successful:
                    _value = "Address validated successfully";
                    AddressVerified = _value;
                    break;
            }*/
            
        }
        public Address(string _name, string _company, string _street1, string _street2, string _street3, string _city,
            string _state, string _postalCode, string _country, string _phone, bool _isResidential, /*AddressVerified*/ string _addressVerified)
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
        public bool? IsResidential { get; set; }
        public /*AddressVerified?*/ string AddressVerified { get; set; }
    }
}