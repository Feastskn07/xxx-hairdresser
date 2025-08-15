using System.ComponentModel.DataAnnotations;

namespace Kuafor.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required, Display(Name = "Kullanıcı Adı veya E-posta")]
        public string UserNameOrEmail { get; set; } = "";

        [Required, DataType(DataType.Password), Display(Name = "Şifre")]
        public string Password { get; set; } = "";

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}