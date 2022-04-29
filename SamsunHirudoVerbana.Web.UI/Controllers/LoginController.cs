using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Data;
using SamsunHirudoVerbana.Web.UI.EmailSender;
using SamsunHirudoVerbana.Web.UI.Models;

namespace SamsunHirudoVerbana.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly INotyfService notyf;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IUserService userService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        public LoginController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment, INotyfService notyf,
            IUserService userService, UserManager<User> userManager, IEmailSender emailSender)
        {
            this.unitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
            this.notyf = notyf;
            this.userService = userService;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Kayıt İşlemleri

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var user = new User() {
                Name= model.Name,
                Surname= model.Surname,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // generate token bilgisi oluşturulacak
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", new {
                    userId = user.Id,
                    token = code
                });
                #region sendingMail
                // email gönderme işlemi
                var pathToFile = hostingEnvironment.WebRootPath
                           + Path.DirectorySeparatorChar.ToString()
                           + "Templates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "MailTemplates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "mail-template-activation-account.html";

                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }

                MailMessage msg = new MailMessage();
                var mailBody = new StringBuilder(builder.HtmlBody);
                msg.IsBodyHtml = true;
                mailBody.Replace("{Username}", user.Name.ToUpper() + " " + user.Surname.ToUpper());
                mailBody.Replace("{url}", url);
                msg.Body = mailBody.ToString();
                msg.Subject = "Hesabınızı Aktifleştirin";


                await _emailSender.SendEmailAsync(model.Email, msg.Subject, msg.Body);
                #endregion
            }
            return RedirectToAction("Index", "Login");
        }


        //Confirm işlemlerini Email 
        //TODO Telefon ile de olacak
        public async Task<IActionResult> ConfirmEmail(int? userId, string Token)
        {
            if (userId == null || Token == null)
            {
                //Genel bri haat mesajı fırlatılacak
                //Notify burda olacak
                TempData["message"] = "Geçersiz";
                return RedirectToAction("Index", new { Message = "Ge.ersiz" });
            }

            var user = await userService.GetById((int)userId);
            

            if (!await _userManager.IsEmailConfirmedAsync(user))
                ModelState.AddModelError("", "hesap aktivasyonunu gerçekleştirin");

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, Token);
                if (result.Succeeded)
                {
                    var pathToFile = hostingEnvironment.WebRootPath
                           + Path.DirectorySeparatorChar.ToString()
                           + "Templates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "MailTemplates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "mail-template-activated-account.html";

                    var builder = new BodyBuilder();
                    using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                    {
                        builder.HtmlBody = SourceReader.ReadToEnd();
                    }

                    MailMessage msg = new MailMessage();
                    var mailBody = new StringBuilder(builder.HtmlBody);
                    msg.IsBodyHtml = true;
                    mailBody.Replace("{UserName}", user.Name.ToUpper() + " " + user.Surname.ToUpper());
                    mailBody.Replace("{url}", "/Home/Index");
                    msg.Body = mailBody.ToString();
                    msg.Subject = "Hesap Aktivasyonu Gerçekleştirilmiştir.";


                    await _emailSender.SendEmailAsync(user.Email, msg.Subject, msg.Body);

                    return View();
                }
            }

            //Hesap onaylanmazsa sıkıntı var denecek sayfada
            // TempData["message"] = "hesap onaylanmadı.";
            return View();
        }
        #endregion

        #region Şifre Unutma İşlemleri
        /// <summary>
        /// Şifreyi unuttum butonuna basıldıktan sonra yönlendirilecek olan sayfa
        /// </summary>
        /// <returns></returns>
        public IActionResult ForgottenPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgottenPassword(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                //Kullanıcı boş bırakılamaz hatası fırlat
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new {
                userId = user.Id,
                token = code
            });
            var pathToFile = hostingEnvironment.WebRootPath
                           + Path.DirectorySeparatorChar.ToString()
                           + "Templates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "MailTemplates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "mail-template-forget-password.html";

            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            MailMessage msg = new MailMessage();
            var mailBody = new StringBuilder(builder.HtmlBody);
            msg.IsBodyHtml = true;
            mailBody.Replace("{UserName}", user.Name.ToUpper() + " " + user.Surname.ToUpper());
            mailBody.Replace("{url}", url);
            msg.Body = mailBody.ToString();
            msg.Subject = "Şifrenizi Sıfırlayın";

            await _emailSender.SendEmailAsync(Email, msg.Subject, msg.Body);

            return RedirectToAction("LogIn", "Account");
        }
        /// <summary>
        /// Email aracılığıyla yönlendirdikten sonra Şifreyi yenileyeceği alan burası olacak
        /// </summary>
        /// <returns></returns>
        public IActionResult ResetPassword(string userId, string token)
        {
            // var user = context.User.GetByStringId(userId);
            if (userId == null || token == null)
            {
                //Hata firlatılacak kullanıcı veya token boş diye
                RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordModel {
                //Email = user.Email,
                Token = token
            };

            return View();
        }
        [HttpPost]
        /// <summary>
        /// Şifre Yenileme
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {//Hata mesajı gönderilecek kullanıcı bulunamadı diye
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("LogIn", "Account");
            }

            return View(model);
        }
        #endregion
    }
}
