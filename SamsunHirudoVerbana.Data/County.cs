using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class County
    {
        public int CountyId { get; set; }
        public string CountyName { get; set; } = null!;
        public int CityId { get; set; }
    }
}
