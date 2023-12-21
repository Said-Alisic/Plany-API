using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Person> People { get; set; }
    }
}
