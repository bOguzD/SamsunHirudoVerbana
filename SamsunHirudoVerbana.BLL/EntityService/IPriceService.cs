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
    public interface IPriceService : IService<Price>
    {
        Currency GetCurrencyByCurrencyCode(string currencyCode);
        //Task InsertPrice(PriceDTO priceDTO);
    }
}
