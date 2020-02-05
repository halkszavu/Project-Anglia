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

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Family> Families { get; set; }
    }
}
