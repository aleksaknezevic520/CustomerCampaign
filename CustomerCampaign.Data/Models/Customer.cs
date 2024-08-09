using CustomerCampaign.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCampaign.Repositories.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SSN { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsLoyal { get; set; }
        public int? HomeAddressId { get; set; }
        public int? WorkAddressId { get; set; }

        public virtual Address HomeAddress { get; set; }
        public virtual Address WorkAddress { get; set; }
        public virtual Reward Reward { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
