using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace TechXpress_Models.ValueObjects
{
    public class Address
    {
        public string Street { get; set; }
         public string City { get; set; }   

         public string State { get; set; }

         public string PostalCode { get; set; } 

         public string Country { get; set; }

         private Address(){

            Street = string.Empty;
            City = string.Empty;
            State = string.Empty;
            PostalCode = string.Empty;
            Country = string.Empty;

         }
         public Address(string street, string city, string state, string postalCode, string country)
         {
            if(string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException("Street can not be empty");
            if(string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException("");
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException("state");


            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;

         }
        public override bool Equals(object? obj)
        {
            if (obj is not Address other) return false;
            return Street == other.Street &&
            City == other.City &&
            State == other.State &&
            PostalCode == other.PostalCode &&
            Country == other.Country;
        //object 
    }
    public override int GetHashCode()
    {
        return HashCode.Combine( Street, City, State, PostalCode, Country );
    }
}
}