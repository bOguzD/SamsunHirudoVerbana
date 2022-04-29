using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int CountryId { get; set; }
    }
}
