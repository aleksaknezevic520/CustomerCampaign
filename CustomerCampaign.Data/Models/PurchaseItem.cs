using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Data.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
