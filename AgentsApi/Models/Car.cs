using System;
using System.Collections.Generic;

namespace AgentsApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string NewUsed { get; set; }
        public int Year { get; set; }
        public int MileageInKm { get; set; }
        public string Price { get; set; } 
        public string Colour { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public string BodyType { get; set; }
        public int Doors { get; set; }
        public decimal EngineCapacityInCc { get; set; } 
        public string FuelType { get; set; }
        public string TransmissionDrive { get; set; }
        public string Transmission { get; set; }
        public int DealerId { get; set; }
        public string DealerLogoUrl { get; set; }
        public int TummCode { get; set; }
        public string RegistrationNumber { get; set; }
        public string ServiceHistory { get; set; }
        public string StockNumber { get; set; }
        public string VehicleCategory { get; set; }
        public List<string> Features { get; set; }
        public DealerContactInformation DealerContactInformation { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public class DealerContactInformation
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string PostalCode { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
