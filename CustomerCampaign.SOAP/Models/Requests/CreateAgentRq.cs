using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.SOAP.Models.Requests
{
    public class CreateAgentRq
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Should have at least 8 characters")]
        public string Password { get; set; }
    }
}
