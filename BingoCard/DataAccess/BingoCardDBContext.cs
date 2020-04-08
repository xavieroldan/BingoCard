using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BingoCard.Models;


namespace BingoCard.DataAccess
{
    public class BingoCardDBContext : DbContext
    {
        public BingoCardDBContext() : base("BingoCardDBContext")
        {
        }

        public DbSet< Player> Players { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Square> Squares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}