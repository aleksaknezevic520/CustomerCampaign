using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Data.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Amount { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
