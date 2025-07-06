using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email adresi alanı zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Şifre Tekrar alanı zorunludur.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
