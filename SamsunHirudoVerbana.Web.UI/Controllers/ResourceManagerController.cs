using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SamsunHirudoVerbana.Web.UI.Controllers
{
    public class ResourceManagerController : Controller
    {
        [HttpPost]
        public IActionResult ChooseCulture(string culture)
        {
            if (culture != null)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = System.DateTimeOffset.UtcNow.AddYears(1) });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
