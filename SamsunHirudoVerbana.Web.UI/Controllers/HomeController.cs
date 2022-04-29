using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SamsunHirudoVerbana.Web.UI.Models;
using System;
using System.Diagnostics;

namespace SamsunHirudoVerbana.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IStringLocalizer<SharedResource> localizer;

        public HomeController(ILogger<HomeController> _logger, IStringLocalizer<SharedResource> _localizer)
        {
            logger = _logger;
            localizer = _localizer;

        }

        public IActionResult Index()
        {
            string msg = localizer["AboutUs"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ChooseCulture(string culture, string returnUrl)
        {
            if (culture != null)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            }
            return Redirect(Request.Headers["Referer"].ToString());
           // return View(returnUrl);
        }
    }
}
