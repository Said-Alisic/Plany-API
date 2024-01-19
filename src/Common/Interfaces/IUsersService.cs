using API.Models;

namespace API.Common.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync(string? email);
}
