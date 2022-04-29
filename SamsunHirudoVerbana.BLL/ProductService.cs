using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.BLL.Service;
using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.BLL
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IMapper mapper;
        private readonly IPictureService pictureService;
        private readonly IPriceService priceService;
        private readonly IInventoryService inventoryService;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository, IMapper mapper, IPictureService pictureService
            ,IPriceService priceService, IInventoryService inventoryService) : base(unitOfWork, repository)
        {
            this.mapper = mapper;
            this.pictureService = pictureService;
            this.priceService = priceService;
            this.inventoryService = inventoryService;
        }

        public async Task InsertProductInfo(ProductDTO productDTO)
        {
            using (TransactionScope tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var product = mapper.Map<Product>(productDTO);
                product.UpdatedDate = DateTime.Now;
                product.CreatedDate = DateTime.Now;
                await Insert(product);

                if (product.ProductId == 0)
                    throw new ArgumentNullException();

                PictureDTO pictureDTO = new PictureDTO();
                pictureDTO.ProductId = product.ProductId;
                pictureDTO.AltText = productDTO.AltText;
                pictureDTO.PictureName = productDTO.PictureName;
                pictureDTO.File = productDTO.File;
                await pictureService.UploadPicture(pictureDTO);

                PriceDTO priceDTO = new PriceDTO();
                priceDTO.CurrencyId = priceService.GetCurrencyByCurrencyCode(productDTO.CurrencyCode).CurrencyId;
                priceDTO.ProductId = product.ProductId;
                priceDTO.IsCurrentPrice = productDTO.IsCurrentPrice;
                priceDTO.IsCampaign = productDTO.IsCampaign;
                priceDTO.UnitPrice = productDTO.UnitPrice;
                var price = mapper.Map<Price>(priceDTO);
                await priceService.Insert(price);

                InventoryDTO inventoryDTO = new InventoryDTO();
                inventoryDTO.ProductId = product.ProductId;
                inventoryDTO.InStockQuantity = productDTO.InStockQuantity;
                inventoryDTO.CreatedDate = DateTime.Now;
                inventoryDTO.UpdatedDate = DateTime.Now;
                var inventory = mapper.Map<Inventory>(inventoryDTO);

                //await inventoryService.InsertInventory(inventory);
                await inventoryService.Insert(inventory);

                await _unitOfWork.CommitAsync();
                tran.Complete();
            };
        }
    }
}
