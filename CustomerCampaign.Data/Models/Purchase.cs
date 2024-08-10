using CustomerCampaign.Repositories.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCampaign.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }

        [NotMapped]
        public decimal Price
        {
            get
            {
                if (PurchaseItems is null || PurchaseItems.Count == 0)
                    return 0;

                return PurchaseItems.Sum(x => x.Amount * x.UnitPrice);
            }
        }

        [NotMapped]
        public decimal? DiscountedPrice
        {
            get
            {
                if (Customer?.Reward is null)
                    return Price;

                return Price * (100 - Customer.Reward.DiscountPercent);
            }
        }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
