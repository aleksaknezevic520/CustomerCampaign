using CustomerCampaign.Infrastructure.Enums;
using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.Services.Helpers
{
    public static class CustomerHelper
    {
        public static Address SetCustomerAddress(Models.Common.Address customerAddress) =>
            customerAddress == null ? null : new Address
            {
                City = customerAddress.City,
                State = customerAddress.State,
                Street = customerAddress.Street,
                Zip = customerAddress.Zip
            };
    }
}
