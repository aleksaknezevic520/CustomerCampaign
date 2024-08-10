using CustomerCampaign.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Price { get; set; }
        public int? RewardId { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Reward Reward { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
