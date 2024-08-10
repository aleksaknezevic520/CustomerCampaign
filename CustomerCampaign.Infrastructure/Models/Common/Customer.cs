using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Infrastructure.Models.Common
{
    public class Customer
    {
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
    }
}
