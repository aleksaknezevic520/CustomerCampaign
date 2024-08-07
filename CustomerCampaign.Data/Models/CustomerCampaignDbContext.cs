using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCampaign.Repositories.Models
{
    public class CustomerCampaignDbContext : DbContext
    {
        public CustomerCampaignDbContext(DbContextOptions<CustomerCampaignDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
    }
}
