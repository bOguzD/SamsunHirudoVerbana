using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; } = null!;
        public decimal? Ratio { get; set; }
        public bool IsDeleted { get; set; }
    }
}
