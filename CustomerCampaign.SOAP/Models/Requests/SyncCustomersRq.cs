using CustomerCampaign.Infrastructure.Models.Common;

namespace CustomerCampaign.SOAP.Models.Requests
{
    public class SyncCustomersRq
    {
        public List<Customer> Customers { get; set; }
    }
}
