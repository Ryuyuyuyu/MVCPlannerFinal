using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCPlannerFinal.Models;

namespace MVCPlannerFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }
    }
}