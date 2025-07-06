using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Models
{
    public class ContactLog
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="İletişim Tarihi alanı zorunludur.")]
        [DisplayName("İletişim Tarihi")]
        public DateTime ContactDate { get; set; } = DateTime.Now;

        [DisplayName("Notlar")]
        public string? Note { get; set; }

        [Required(ErrorMessage ="İletişim Yöntemi alanı zorunludur.")]
        [DisplayName("İletişim Yöntemi")]
        public string ContactMethod { get; set; }

        [Required(ErrorMessage ="Müşteri alanı zorunludur.")]
        public int CustomerId { get; set; }

        [ValidateNever]
        [DisplayName("Müşteri")]
        public Customer Customer { get; set; }
    }
}
