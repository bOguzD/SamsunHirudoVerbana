using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Data
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }
        public string AltText { get; set; }
        public int? ProductId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
