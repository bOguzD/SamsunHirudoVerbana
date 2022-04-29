using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SamsunHirudoVerbana.BLL.DTOs
{
    public class PictureDTO
    {
        public string PictureName { get; set; }
        public string PicturePath { get; set; }
        public string AltText { get; set; }
        public int? ProductId { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
