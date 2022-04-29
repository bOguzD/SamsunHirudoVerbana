using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.BLL.DTOs
{
    public class InventoryDTO
    {
        public int ProductId { get; set; }
        public int InStockQuantity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
