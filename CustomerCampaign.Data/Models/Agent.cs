using System.ComponentModel.DataAnnotations;

namespace CustomerCampaign.Repositories.Models
{
    public class Agent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Should have at least 8 characters")]
        public string Password { get; set; }

        public virtual ICollection<Reward> AssignedByRewards { get; set; }
    }
}
