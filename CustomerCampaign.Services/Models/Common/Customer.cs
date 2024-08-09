using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Services.Models.Common
{
    public class Customer
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SSN { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
    }
}
