using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }

        // TODO: Define DbSet properties for the CalendarEvent entity
    }
}
