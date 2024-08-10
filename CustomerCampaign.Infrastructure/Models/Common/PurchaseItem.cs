namespace CustomerCampaign.Infrastructure.Models.Common
{
    public class PurchaseItem
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseoriginalTotalPrice { get; set; }
        public decimal? PurchaseDiscount { get; set; }
        public decimal? PurchaseDiscountedTotalPrice { get; set; }
        public string CustomerName { get; set; }
        public int PurchaseItemId { get; set; }
        public string PurchaseItemName { get; set; }
        public int PurchaseItemAmount { get; set; }
        public decimal PurchaseItemUnitPrice { get; set; }
    }
}
