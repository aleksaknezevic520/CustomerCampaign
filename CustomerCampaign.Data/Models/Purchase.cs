﻿using CustomerCampaign.Repositories.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCampaign.Data.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        public int CustomerId { get; set; }

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
