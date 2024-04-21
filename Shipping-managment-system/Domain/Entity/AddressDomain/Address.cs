using Shipping_managment_system.Domain.Abstraction;
using System.Runtime;

namespace Shipping_managment_system.Domain.Entity.AddressDomain
{
    public class Address : Entity<AddressId>
    {
        public Address(AddressId id,string state, string city, double lat, double lon, string? isoCode, string? house_number, string? postCode, string? road, string? village) :base(id)
        {
            State = state;
            City = city;
            Lat = lat;
            Lon = lon;
            IsoCode = isoCode;
            House_number = house_number;
            PostCode = postCode;
            Road = road;
            Village = village;
        }
        public double Lat { get; private set; }
        public double Lon { get; private set; }
        public string? IsoCode { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string? House_number { get; private set; }
        public string? PostCode { get; private set; }
        public string? Road { get; private set; }
        public string? Village { get; private set; }


        public static Address Create(string state, string city, double lat, double lon, string? isoCode, string? house_number, string? postCode, string? road, string? village)
        {
            return new(AddressId.CreateUnique(),state, city, lat, lon, isoCode, house_number, postCode, road, village);
        }


        public void Update(string state, string city, double lat, double lon, string? isoCode, string? house_number, string? postCode, string? road, string? village)
        {
            State = state;
            City = city;
            Lat = lat;
            Lon = lon;
            IsoCode = isoCode;
            House_number = house_number;
            PostCode = postCode;
            Road = road;
            Village = village;
        }


    }
}
