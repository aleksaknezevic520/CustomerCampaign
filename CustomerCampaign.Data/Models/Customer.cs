using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCampaign.Repositories.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public int? HomeAddressId { get; set; }
        public int? WorkAddressId { get; set; }
        public virtual Address? HomeAddress { get; set; }
        public virtual Address? WorkAddress { get; set; }
    }
}
