using AutoMapper;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.Data;
using SamsunHirudoVerbana.Web.UI.Areas.Admin.Models;

namespace SamsunHirudoVerbana.Web.UI.AutoMapper
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            //Service katmanına taşınacak
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<PictureDTO, Picture>();
            CreateMap<Picture, PictureDTO>();

            CreateMap<PriceDTO, Price>();
            CreateMap<Price, PriceDTO>();

            CreateMap<InventoryDTO, Inventory>();
            CreateMap<Inventory, InventoryDTO>();

        }

    }
}
