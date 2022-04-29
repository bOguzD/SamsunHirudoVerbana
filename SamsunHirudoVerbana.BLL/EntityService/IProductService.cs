using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.Service;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.BLL.EntityService
{
    public interface IProductService : IService<Product>
    {
        Task InsertProductInfo(ProductDTO productDTO);

    }
}
