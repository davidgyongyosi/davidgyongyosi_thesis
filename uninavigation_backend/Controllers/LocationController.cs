using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using uninavigation_backend.Logic.Classes;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models;
using uninavigation_backend.Models.DTOs;

namespace uninavigation_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationLogic _locationLogic;

        public LocationController(ILocationLogic locationLogic)
        {
            _locationLogic = locationLogic;
            
        }

        [HttpGet]
        public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync()
        {
            var locations = await _locationLogic.GetAllLocationsAsync();

            var locationDTOs = locations.Select(l => new LocationDTO
            {
                Id = l.Id,
                Name = l.Name
            });

            return locationDTOs;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocationsAsync(ICollection<LocationDTO> locations)
        {
            var LocationModels = new List<Location>();

            foreach (var loc in locations)
            {
                var locModel = new Location()
                {
                    Id = loc.Id,
                    Name = loc.Name,
                    ar_Content = loc.ar_Content
                };
                LocationModels.Add(locModel);

            }

            await _locationLogic.AddLocationsAsync(LocationModels);

            return Ok(new { message = "Done" });


        }

        [HttpDelete]
        public async Task DeleteLocationAsync(string locationId)
        {
            await _locationLogic.DeleteLocationAsync(locationId);
        }

        [HttpPut]
        public async Task UpdateLocationAsync(Location location)
        {
            await _locationLogic.UpdateLocationAsync(location);
        }

        [HttpGet("restore")]
        public async Task<IActionResult> RestoreLocationsAsync()
        {
            var locations = await _locationLogic.GetAllLocationsAsync();

            if(locations is not null)
            {
                foreach (var loc in locations)
                {
                    await _locationLogic.DeleteLocationAsync(loc.Id);
                }
            }

            return Ok(new { message = "Done" });
        }
    }
}

