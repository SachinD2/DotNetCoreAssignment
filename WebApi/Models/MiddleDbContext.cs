using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApi_Assign.Models
{
    public class MiddleDbContext : DbContext
    {
        public MiddleDbContext(DbContextOptions<MiddleDbContext> options): base(options)
        {
        }

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
           
        }

     //   partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
