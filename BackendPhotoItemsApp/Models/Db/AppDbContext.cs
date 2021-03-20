using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackendPhotoItemsApp.Models.Db
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemPhoto> ItemPhotos { get; set; }
        public virtual DbSet<ItemPhotoPropertySet> ItemPhotoPropertySets { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<TypePropertySet> TypePropertySets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ItemPhoto>(entity =>
            {
                entity.Property(e => e.Alt).HasMaxLength(500);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemPhotos)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemPhotos_Items");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ItemPhotos)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPhotos_Types");
            });

            modelBuilder.Entity<ItemPhotoPropertySet>(entity =>
            {
                entity.ToTable("ItemPhotoPropertySet");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ItemPhoto)
                    .WithMany(p => p.ItemPhotoPropertySets)
                    .HasForeignKey(d => d.ItemPhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPhotoPropertySet_ItemPhotos");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.ItemPhotoPropertySets)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPhotoPropertySet_ItemPhotoPropertySet");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypePropertySet>(entity =>
            {
                entity.ToTable("TypePropertySet");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.TypePropertySets)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypePropertySet_Types");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.TypePropertySets)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypePropertySet_Properties");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
