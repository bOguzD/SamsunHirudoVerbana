using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SamsunHirudoVerbana.BLL.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int InStockQuantity { get; set; }
        public string CurrencyCode { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsCampaign { get; set; }
        public bool IsCurrentPrice { get; set; }
        public string PictureName { get; set; }
        public string AltText { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        //public PictureDTO pictureDTO { get; set; }
    }
}
