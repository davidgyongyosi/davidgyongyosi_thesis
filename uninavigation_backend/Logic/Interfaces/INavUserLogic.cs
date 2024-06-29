using System;
using uninavigation_backend.Models;

namespace uninavigation_backend.Logic.Interfaces
{
    public interface INavUserLogic
    {
        Task<IEnumerable<NavUser>> GetAllUsersAsync();
        Task<NavUser> GetUserByIdAsync(string userId);
        Task UpdateUserAsync(NavUser user);
        Task DeleteUserAsync(string userId);
    }
}

