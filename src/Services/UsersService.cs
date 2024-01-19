// Define the service interface
using API.Common.Interfaces;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly ApiDbContext _apiDbContext;

        public UserService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext ?? throw new ArgumentNullException(nameof(apiDbContext));

            _apiDbContext.Database.EnsureCreated();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string? email)
        {
            IQueryable<User> query = _apiDbContext.Users;

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(item => item.Email.Equals(email));
            }

            return await query.ToArrayAsync() ?? Enumerable.Empty<User>();
        }
    }
}
