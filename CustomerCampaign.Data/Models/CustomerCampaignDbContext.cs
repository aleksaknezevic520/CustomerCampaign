using CustomerCampaign.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
                .HasIndex(a => a.Email)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.SSN)
                .IsUnique();
            modelBuilder.Entity<Reward>()
                .HasIndex(r => new { r.AgentId, r.CustomerId, r.CreatedDate })
                .IsUnique();
            modelBuilder.Entity<Reward>()
                .HasKey(r => new { r.AgentId, r.CustomerId });
            modelBuilder.Entity<PurchaseItem>()
                .HasKey(pi => new { pi.Id, pi.PurchaseId});
            modelBuilder.Entity<PurchaseItem>()
                .HasOne(pi => pi.Purchase)
                .WithMany(p => p.PurchaseItems);
        }
    }
}
