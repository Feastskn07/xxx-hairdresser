using System.ComponentModel.DataAnnotations;

namespace Kuafor.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Ad")]
        public string FirstName { get; set; } = "";

        [Required, Display(Name = "Soyad")]
        public string LastName { get; set; } = "";

        [Required, StringLength(30, MinimumLength = 3), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; } = "";

        [Required, EmailAddress, Display(Name = "E-posta")]
        public string Email { get; set; } = "";

        [Phone, Display(Name = "Telefon")]
        public string Phone { get; set; } = "";

        [Required, MinLength(6), DataType(DataType.Password), Display(Name = "Şifre")]
        public string Password { get; set; } = "";

        [Required, DataType(DataType.Password), Display(Name = "Şifre (Tekrar)"),
         Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = "";

        [Display(Name = "Duyuru ve teklifler için e-posta almak istiyorum")]
        public bool Newsletter { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Kullanıcı sözleşmesini kabul etmelisiniz.")]
        [Display(Name = "Kullanıcı sözleşmesini kabul ediyorum")]
        public bool Terms { get; set; }
    }
}