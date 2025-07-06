using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad-Soyad alanı boş geçilemez!")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez!")]
        [RegularExpression(@"^\+?[0-9]{11}$", ErrorMessage = "Lütfen geçerli bir telefon numarası girin!")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez!")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreationTime { get; set; } = DateTime.Now;

        [ValidateNever]
        public List<Policy> Policies { get; set; }

        [ValidateNever]
        public List<ContactLog> ContactLogs { get; set; }
    }
}
