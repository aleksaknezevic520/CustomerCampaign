using AddressCommon = CustomerCampaign.Infrastructure.Models.Common.Address;
using CustomerCampaign.Repositories.Models;

namespace CustomerCampaign.SOAP.Helpers
{
    public static class CustomerHelper
    {
        public static Address MapCustomerAddress(AddressCommon customerAddress) =>
            customerAddress == null ? null : new Address
            {
                City = customerAddress.City,
                State = customerAddress.State,
                Street = customerAddress.Street,
                Zip = customerAddress.Zip
            };
    }
}
