using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace datamodel
{
    public partial class adsdbContext : DbContext
    {
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Advertiser> Advertiser { get; set; }
        public virtual DbSet<AdvertisingCompany> AdvertisingCompany { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WebMaster> WebMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"data source=LENOVO-PC;initial catalog=adsdb;persist security info=True;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;App=adshost");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_Admin#Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsSuper).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Advertiser>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_Advertiser#Name")
                    .IsUnique();
            });

            modelBuilder.Entity<AdvertisingCompany>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_AdvertisingCompany#Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_Manager#Name")
                    .IsUnique();
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_Partner#Name")
                    .IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_User#Name")
                    .IsUnique();
            });

            modelBuilder.Entity<WebMaster>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_WebMaster#Name")
                    .IsUnique();
            });
        }
    }
}