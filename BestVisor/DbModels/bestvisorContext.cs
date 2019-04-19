using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BestVisor.DbModels
{
    public partial class bestvisorContext : DbContext
    {
        public bestvisorContext()
        {
        }

        public bestvisorContext(DbContextOptions<bestvisorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kampanya> Kampanya { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<Sektorler> Sektorler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TQLP6O6;Initial Catalog=bestvisor;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kampanya>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignDesc)
                    .HasColumnName("campaignDesc")
                    .HasMaxLength(300);

                entity.Property(e => e.CampaignName)
                    .HasColumnName("campaignName")
                    .HasMaxLength(20);

                entity.Property(e => e.SektorList)
                    .HasColumnName("sektorList")
                    .HasMaxLength(50);


                entity.Property(e => e.CampaignSms)
                    .HasColumnName("campaignSms")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sektorler>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SectorName)
                    .HasColumnName("sectorName");
                
            });
            modelBuilder.Entity<Musteriler>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Campaign).HasColumnName("campaign");

                entity.Property(e => e.CardLimit).HasColumnName("cardLimit");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Ecommerce).HasColumnName("ecommerce");

                entity.Property(e => e.GenderFemale).HasColumnName("genderFemale");

                entity.Property(e => e.Installments).HasColumnName("installments");

                entity.Property(e => e.LoanDebt).HasColumnName("loanDebt");

                entity.Property(e => e.MerchantId).HasColumnName("merchantId");

                entity.Property(e => e.ShopFrequence).HasColumnName("shopFrequence");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.VirtualCard).HasColumnName("virtualCard");

                entity.Property(e => e.VirtualCardSf).HasColumnName("virtualCardSF");
            });
        }
    }
}
