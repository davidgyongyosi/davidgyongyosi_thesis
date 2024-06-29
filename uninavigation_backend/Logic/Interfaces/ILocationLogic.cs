using System;
using uninavigation_backend.Models;

namespace uninavigation_backend.Logic.Interfaces
{
	public interface ILocationLogic
	{
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task AddLocationsAsync(ICollection<Location> location);
        Task UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(string locationId);
    }
}

