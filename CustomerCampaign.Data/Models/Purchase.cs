using CustomerCampaign.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int? RewardId { get; set; }
        public decimal? DiscountedPrice { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Reward Reward { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
