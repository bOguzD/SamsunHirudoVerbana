using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.BLL.Service;
using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.BLL
{
    public class PriceService : Service<Price>, IPriceService
    {
        private readonly IMapper mapper;
        public PriceService(IUnitOfWork unitOfWork, IRepository<Price> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            this.mapper = mapper;
        }

        public Currency GetCurrencyByCurrencyCode(string currencyCode)
        {
            return _unitOfWork.Currency.Where(x => x.CurrencyCode == currencyCode).Result.FirstOrDefault();
        }

        //public async Task InsertPrice(PriceDTO priceDTO)
        //{
        //    try
        //    {
        //        var price = mapper.Map<Price>(priceDTO);
        //        await Insert(price);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
    }
}
