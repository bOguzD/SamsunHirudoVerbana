using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int? CustomerId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? CountyId { get; set; }
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public int? PostalCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
