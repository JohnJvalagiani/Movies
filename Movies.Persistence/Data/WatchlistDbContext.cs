using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence.Data
{
    public class WatchlistDbContext : DbContext
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options) : base(options)
        {
        }

        public DbSet<WatchlistItem> WatchlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchlistItem>().HasKey(w => w.Id);
        }
    }
}
