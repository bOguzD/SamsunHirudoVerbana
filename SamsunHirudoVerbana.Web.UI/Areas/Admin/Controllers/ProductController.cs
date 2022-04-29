using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Web.UI.Areas.Admin.Models;
using SamsunHirudoVerbana.Data;
using System.Transactions;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SamsunHirudoVerbana.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly INotyfService notyf;
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IPictureService pictureService;
        private readonly IInventoryService inventoryService;
        private readonly IPriceService priceService;
        public ProductController(INotyfService notyf, IProductService productService, IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment, IPictureService pictureService,
            IInventoryService inventoryService, IPriceService priceService)
        {
            this.notyf = notyf;
            this.productService = productService;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
            this.pictureService = pictureService;
            this.inventoryService = inventoryService;
            this.priceService = priceService;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await productService.GetAll();
            IEnumerable<ProductViewModel> productModelList = mapper.Map<IEnumerable<ProductViewModel>>(productList);
            return View(productModelList);
        }

        public Product GetProductById(int productId)
        {
            return productService.GetById(productId).Result;
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                {
                    notyf.Warning("Lütfen ürün alanlarını doldurunuz.");
                    return RedirectToAction("AddProduct");
                }
                if (productDTO.CurrencyCode == null)
                {
                    notyf.Warning("Lütfen para birimini seçiniz.");
                    return RedirectToAction("AddProduct");
                }
                if (productDTO.InStockQuantity == 0 || productDTO.UnitPrice == 0)
                {
                    notyf.Warning("Ürün fiyatı ve stok bilgisi sıfırdan fazla olmalıdır.");
                    return RedirectToAction("AddProduct");
                }

                await productService.InsertProductInfo(productDTO);

                //using (TransactionScope tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                //{
                //    var product = mapper.Map<Product>(productDTO);
                //    product.UpdatedDate = DateTime.Now;
                //    product.CreatedDate = DateTime.Now;
                //    await productService.Insert(product);

                //    if (product.ProductId == 0)
                //        throw new ArgumentNullException();

                //    PictureDTO pictureDTO = new PictureDTO();
                //    pictureDTO.ProductId = product.ProductId;
                //    pictureDTO.AltText = productDTO.AltText;
                //    pictureDTO.PictureName = productDTO.PictureName;
                //    pictureDTO.File = productDTO.File;
                //    UploadPicture(pictureDTO);


                //    PriceDTO priceDTO = new PriceDTO();
                //    priceDTO.CurrencyId = priceService.GetCurrencyByCurrencyCode(productDTO.CurrencyCode).CurrencyId;
                //    priceDTO.ProductId = product.ProductId;
                //    priceDTO.IsCurrentPrice = productDTO.IsCurrentPrice;
                //    priceDTO.IsCampaign = productDTO.IsCampaign;
                //    priceDTO.UnitPrice = productDTO.UnitPrice;
                //    var price = mapper.Map<Price>(priceDTO);
                //    await priceService.Insert(price);

                //    InventoryDTO inventoryDTO = new InventoryDTO();
                //    inventoryDTO.ProductId = product.ProductId;
                //    inventoryDTO.InStockQuantity = productDTO.InStockQuantity;
                //    //inventoryDTO.CreatedDate = DateTime.Now;
                //    //inventoryDTO.UpdatedDate = DateTime.Now;
                //    var inventory = mapper.Map<Inventory>(inventoryDTO);

                //    await inventoryService.Insert(inventory);


                //    await unitOfWork.CommitAsync();
                //    tran.Complete();
                //};



                notyf.Success(productDTO.ProductName + " adlı ürün başarı ile eklendi.");
                return RedirectToAction("Index");
            }
            catch(ArgumentNullException ex)
            {
                notyf.Error(ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                notyf.Error(ex.Message);
                return View();
            }
        }

        //        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var product = GetProductById(productId);

            if (product != null)
            {
                var price = priceService.GetById(productId);
                var picture = pictureService.GetById(productId);


                //priceService.Delete(price);
                //pictureService.Delete(picture);

                productService.Delete(product);
            }
            else
            {
                notyf.Error("Silinmek istenen ürün bulunamadı");
            }

            return RedirectToAction("Index");

        }

        public IActionResult EditProduct(int productId)
        {
            Product product = GetProductById(productId);
            ProductViewModel productModel = new ProductViewModel();
            productModel.ProductId = productId;
            productModel.ProductName = product.ProductName;
            productModel.Description = product.Description;
            return PartialView("_EditProduct", productModel);
        }


        //public async void UploadPicture(PictureDTO model)
        //{
        //    try
        //    {
        //        if (model == null)
        //        {
        //            const string message = "Fotoğraf veya resim yüklenemesi tamamlanamadı. Dosyayı düzgün yüklediğinizden emin olun.";
        //            //notyf.Error(message)
        //            throw new Exception(message);
        //        }
        //        if (string.IsNullOrWhiteSpace(model.PictureName) || string.IsNullOrWhiteSpace(model.AltText))
        //        {
        //            const string message = "Lütfen fotoğraf adını veya fotoğraf ile ilgili kelime tanımını boş bırakmayınız.";
        //            //notyf.Warning(message);
        //            throw new Exception(message);
        //        }

        //        string filePath = hostingEnvironment.WebRootPath + "/ProductImages/";
        //        bool filePathExist = Directory.Exists(filePath);
        //        if (!filePathExist)
        //            Directory.CreateDirectory(filePath);

        //        //Save image to wwwroot
        //        string wwwrootPath = hostingEnvironment.WebRootPath;
        //        string extention = Path.GetExtension(model.File.FileName);
        //        model.PictureName = model.PictureName + extention;
        //        string path = Path.Combine(wwwrootPath, "ProductImages", model.PictureName);

        //        using (var fileStream = new FileStream(path, FileMode.Create))
        //        {
        //            model.File.CopyTo(fileStream);
        //        }
                
        //        model.PicturePath = path;

        //        Picture picEntity = mapper.Map<Picture>(model);
        //        await pictureService.Insert(picEntity);
        //        await unitOfWork.CommitAsync();
        //    }
        //    catch (Exception ex) {
        //        throw new Exception("Beklenmeyen hata oluştu", ex.InnerException);
        //    }

        //}
    }
}
