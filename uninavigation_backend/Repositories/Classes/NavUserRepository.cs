using System;
using Microsoft.EntityFrameworkCore;
using uninavigation_backend.Data;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Repositories.Classes
{
    public class NavUserRepository : INavUserRepository
    {
        private readonly ApplicationDbContext _context;

        public NavUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NavUser>> GetAllUsersAsync()
        {
            return await _context.NavUsers.ToListAsync();
        }

        public async Task<NavUser> GetUserByIdAsync(string userId)
        {
            return await _context.NavUsers.FindAsync(userId);
        }

        public async Task UpdateUserAsync(NavUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _context.NavUsers.FindAsync(userId);
            if (user != null)
            {
                _context.NavUsers.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

