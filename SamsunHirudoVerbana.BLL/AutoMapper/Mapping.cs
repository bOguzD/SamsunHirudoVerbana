using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            //CreateMap<Product, ProductDTO>();

            CreateMap<PictureDTO, Picture>().ReverseMap();
            //CreateMap<Picture, PictureDTO>();

            CreateMap<PriceDTO, Price>().ReverseMap();
            //CreateMap<Price, PriceDTO>();

            CreateMap<InventoryDTO, Inventory>().ReverseMap();
            //CreateMap<Inventory, InventoryDTO>();


        }
    }
}
