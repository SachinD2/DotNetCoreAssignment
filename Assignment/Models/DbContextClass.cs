using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CheckUserRole.Models
{
    public class DbContextClass : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=IMCABCP32-MSL1;Initial Catalog=CitusAssign;Integrated Security=SSPI;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                 .HasOne(v => v.Roles)
                 .WithMany(p => p.Users)
                 .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(c => c.RoleId).IsUnique();

            });
        }

        }
    }
