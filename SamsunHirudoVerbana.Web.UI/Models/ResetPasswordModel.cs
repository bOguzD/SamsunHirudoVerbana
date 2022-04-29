using System.ComponentModel.DataAnnotations;

namespace SamsunHirudoVerbana.Web.UI.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string Email { get; set; }
    }
}
