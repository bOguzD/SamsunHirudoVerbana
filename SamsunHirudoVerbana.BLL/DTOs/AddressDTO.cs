using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.BLL.DTOs
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string AddressLine1 { get; set; }
        public bool IsDeleted { get; set; }
    }
}
