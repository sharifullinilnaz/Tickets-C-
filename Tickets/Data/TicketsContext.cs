using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Tickets.Data
{
    public class TicketsContext : DbContext
    {
        public TicketsContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    }
}
