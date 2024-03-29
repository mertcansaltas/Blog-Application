using System.ComponentModel.DataAnnotations;
using BlogUI.Controllers;

namespace BlogUI.Models.VMs
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email Adresi Zorunludur.")]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Şifreler Tutarsız")]
        public string ConfirmPassword { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
