using System;
using Microsoft.EntityFrameworkCore;
using uninavigation_backend.Data;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Repositories.Classes
{
	public class LocationRepository: ILocationRepository
	{
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task AddLocationsAsync(ICollection<Location> location)
        {
            foreach (var loc in location)
            {
                _context.Locations.Add(loc);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(string locationId)
        {
            var location = await _context.Locations.FindAsync(locationId);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }

    }
}

