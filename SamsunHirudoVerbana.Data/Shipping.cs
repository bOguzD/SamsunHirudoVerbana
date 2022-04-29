using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class Shipping
    {
        public int ShippingId { get; set; }
        public string ShippingName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
