using System;
using uninavigation_backend.Models;

namespace uninavigation_backend.Repositories.Interfaces
{
    public interface INavUserRepository
    {
        Task<IEnumerable<NavUser>> GetAllUsersAsync();
        Task<NavUser> GetUserByIdAsync(string userId);
        Task UpdateUserAsync(NavUser user);
        Task DeleteUserAsync(string userId);
    }
}

