using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using uninavigation_backend.Data;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Repositories.Classes
{
    public class ArContentRepository : IArContentRepository
	{
        private readonly ApplicationDbContext _context;

        public ArContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ar_content>> GetAllContentAsync()
        {
            return await _context.Ar_Contents.ToListAsync();
        }

        public async Task<Ar_content> GetContentByIdAsync(int arContentId)
        {
            return await _context.Ar_Contents.FindAsync(arContentId);
        }

        public async Task AddContentAsync(Ar_content ar_Content)
        {
            _context.Ar_Contents.Add(ar_Content);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContentAsync(Ar_content ar_Content)
        {
            _context.Entry(ar_Content).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContentAsync(int arContentId)
        {
            var item = await _context.Ar_Contents.FindAsync(arContentId);
            if (item != null)
            {
                _context.Ar_Contents.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}

