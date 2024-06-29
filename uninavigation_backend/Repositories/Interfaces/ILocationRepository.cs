using System;
using Microsoft.EntityFrameworkCore;
using uninavigation_backend.Models;

namespace uninavigation_backend.Repositories.Interfaces
{
	public interface ILocationRepository
	{
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task AddLocationsAsync(ICollection<Location> location);
        Task UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(string locationId);

    }
}

