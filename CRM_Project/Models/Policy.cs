using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_Project.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Poliçe Numarası")]
        public string PolicyNumber { get; set; }

        [Required]
        [DisplayName("Sigorta Türü")]
        public string Type { get; set; }

        [DisplayName("Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }

        [ValidateNever]
        [DisplayName("Müşteri")]
        public Customer Customer { get; set; }
    }
}
