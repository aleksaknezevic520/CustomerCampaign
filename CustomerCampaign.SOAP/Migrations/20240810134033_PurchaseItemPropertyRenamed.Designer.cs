﻿// <auto-generated />
using System;
using CustomerCampaign.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerCampaign.SOAP.Migrations
{
    [DbContext(typeof(CustomerCampaignDbContext))]
    [Migration("20240810134033_PurchaseItemPropertyRenamed")]
    partial class PurchaseItemPropertyRenamed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerCampaign.Data.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CustomerCampaign.Data.Models.PurchaseItem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id", "PurchaseId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseItems");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HomeAddressId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLoyal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("WorkAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HomeAddressId");

                    b.HasIndex("SSN")
                        .IsUnique();

                    b.HasIndex("WorkAddressId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Reward", b =>
                {
                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AgentId", "CustomerId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("AgentId", "CustomerId", "CreatedDate")
                        .IsUnique();

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("CustomerCampaign.Data.Models.Purchase", b =>
                {
                    b.HasOne("CustomerCampaign.Repositories.Models.Customer", "Customer")
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerCampaign.Data.Models.PurchaseItem", b =>
                {
                    b.HasOne("CustomerCampaign.Data.Models.Purchase", "Purchase")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Customer", b =>
                {
                    b.HasOne("CustomerCampaign.Repositories.Models.Address", "HomeAddress")
                        .WithMany()
                        .HasForeignKey("HomeAddressId");

                    b.HasOne("CustomerCampaign.Repositories.Models.Address", "WorkAddress")
                        .WithMany()
                        .HasForeignKey("WorkAddressId");

                    b.Navigation("HomeAddress");

                    b.Navigation("WorkAddress");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Reward", b =>
                {
                    b.HasOne("CustomerCampaign.Repositories.Models.Agent", "Agent")
                        .WithMany("AssignedByRewards")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerCampaign.Repositories.Models.Customer", "Customer")
                        .WithOne("Reward")
                        .HasForeignKey("CustomerCampaign.Repositories.Models.Reward", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerCampaign.Data.Models.Purchase", b =>
                {
                    b.Navigation("PurchaseItems");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Agent", b =>
                {
                    b.Navigation("AssignedByRewards");
                });

            modelBuilder.Entity("CustomerCampaign.Repositories.Models.Customer", b =>
                {
                    b.Navigation("Purchases");

                    b.Navigation("Reward");
                });
#pragma warning restore 612, 618
        }
    }
}
