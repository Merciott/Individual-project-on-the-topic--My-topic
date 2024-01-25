using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fashion.Models
{
    public partial class DruzhkoFashionContext : DbContext
    {
        public DruzhkoFashionContext() // Конструктор по умолчанию
        {
        }

        public DruzhkoFashionContext(DbContextOptions<DruzhkoFashionContext> options) // Конструктор с параметром для настройки контекста базы данных
            : base(options) 
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!; // Свойство для работы с таблицей "Brand"
        public virtual DbSet<Polzovatel> Polzovatels { get; set; } = null!; // Свойство для работы с таблицей "Polzovatel"
        public virtual DbSet<Product> Products { get; set; } = null!; // Свойство для работы с таблицей "Product"
        public virtual DbSet<Review> Reviews { get; set; } = null!; // Свойство для работы с таблицей "Review"
        public virtual DbSet<Zakazi> Zakazis { get; set; } = null!; // Свойство для работы с таблицей "Zakazi"

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Метод для настройки схемы базы данных
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Brand1)
                    .HasColumnType("text")
                    .HasColumnName("Brand");
            });

            modelBuilder.Entity<Polzovatel>(entity =>
            {
                entity.ToTable("Polzovatel");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Products__BrandI__3F466844");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__UserID__412EB0B6");
            });

            modelBuilder.Entity<Zakazi>(entity =>
            {
                entity.ToTable("Zakazi");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Zakazis)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Zakazi_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Zakazis)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zakazi__UserID__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder); // Часть метода OnModelCreatin (26 строка) для дополнительной настройки схемы базы данных
    }

}
