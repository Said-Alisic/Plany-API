using API.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618

namespace API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>().HasKey(p => new { p.CalendarEventId, p.PersonId });
        }
    }
}
