using System;
using Microsoft.Extensions.Logging;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Classes;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Logic.Classes
{
    public class LocationLogic : ILocationLogic
	{
        private readonly ILocationRepository _locationRepository;

        public LocationLogic(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task AddLocationsAsync(ICollection<Location> location)
        {
            await _locationRepository.AddLocationsAsync(location);
        }

        public async Task DeleteLocationAsync(string locationId)
        {
            await _locationRepository.DeleteLocationAsync(locationId);
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _locationRepository.GetAllLocationsAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            await _locationRepository.UpdateLocationAsync(location);
        }
    }
}

