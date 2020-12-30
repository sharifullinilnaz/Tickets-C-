using Tickets.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Tickets.Data
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne<Event>(t => t.Event)
                .WithMany(e => e.Tickets);
        }
    }
}
