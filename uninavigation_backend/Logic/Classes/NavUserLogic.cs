using System;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Classes;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Logic.Classes
{
    public class NavUserLogic : INavUserLogic
    {
        private readonly INavUserRepository _userRepository;

        public NavUserLogic(INavUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<IEnumerable<NavUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<NavUser> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task UpdateUserAsync(NavUser eventItem)
        {
            await _userRepository.UpdateUserAsync(eventItem);
        }

        public async Task DeleteUserAsync(string userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}

