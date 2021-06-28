using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core_WebApi.Models
{
    public partial class AllDbContext : DbContext
    {
        //public CitusTrainingContext()
        //{
        //}

        public AllDbContext(DbContextOptions<AllDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<MiddlewareClass> MiddlewareClasses  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CitusTraining;Integrated Security=SSPI");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryRowId);

                entity.HasIndex(e => e.CategoryId)
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductRowId);

                entity.HasIndex(e => e.CategoryRowId);

                entity.HasIndex(e => e.ProductId)
                    .IsUnique();

                entity.Property(e => e.Desicription)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ProductId).IsRequired();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CategoryRow)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryRowId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Resul)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<MiddlewareClass>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.HasIndex(e => e.LogId)
                    .IsUnique();

                entity.Property(e => e.LogId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LogGUID)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Request)
                    .IsRequired();
                entity.Property(e => e.ControllerName)
                   .IsRequired();
                entity.Property(e => e.ActionName)
                   .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
