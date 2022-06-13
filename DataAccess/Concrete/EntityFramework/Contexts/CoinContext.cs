using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class CoinContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=CoinDb; Trusted_Connection=True;");
        }

        public DbSet<Coin> Coins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coin>().Property(x => x.CurrentPrice).HasPrecision(18, 6);
            modelBuilder.Entity<Coin>().Property(x => x.RateOfChange).HasPrecision(18, 6);
        }
    }
}
