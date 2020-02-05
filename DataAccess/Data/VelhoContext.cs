using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Anglia.Data
{
    class VelhoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AngliaDB.mdf");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().ToTable("Living");
            modelBuilder.Entity<Agent>().ToTable("Dead");
            modelBuilder.Entity<Family>().ToTable("Families");
        }

        public DbSet<Agent> Living { get; set; }
        public DbSet<Agent> Dead { get; set; }
        public DbSet<Family> Families { get; set; }
    }
}
