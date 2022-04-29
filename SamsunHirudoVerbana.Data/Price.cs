using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class Price
    {
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCampaign { get; set; }
        public bool IsCurrentPrice { get; set; }
    }
}
