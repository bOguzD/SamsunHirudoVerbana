using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.Core;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Data;
using SamsunHirudoVerbana.Web.UI.Areas.Admin.Models;

namespace SamsunHirudoVerbana.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly INotyfService notyf;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment, INotyfService notyf, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
            this.notyf = notyf;
            this.mapper = mapper;

        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
