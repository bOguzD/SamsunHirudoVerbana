using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.BLL.DTOs
{
    public class PriceDTO
    {
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCampaign { get; set; }
        public bool IsCurrentPrice { get; set; }
    }
}
