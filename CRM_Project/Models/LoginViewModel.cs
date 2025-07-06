using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email adresi alanı zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
