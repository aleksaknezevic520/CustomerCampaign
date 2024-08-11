namespace CustomerCampaign.SOAP.Models.Requests
{
    public class UpdateCustomerLoyaltyStatusRq
    {
        public int CustomerId { get; set; }
        public bool IsLoyal { get; set; }
    }
}
