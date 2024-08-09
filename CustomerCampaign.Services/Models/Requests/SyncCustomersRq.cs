using CustomerCampaign.Services.Models.Common;
using System.Threading.Tasks;

namespace CustomerCampaign.Services.Models.Requests
{
    public class SyncCustomersRq
    {
        public List<Customer> Customers { get; set; }
    }
}
