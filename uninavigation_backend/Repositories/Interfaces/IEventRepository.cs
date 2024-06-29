using System;
using uninavigation_backend.Models;

namespace uninavigation_backend.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetEventsByUserIdAsync(string userId);
        Task AddEventAsync(Event eventItem);
        Task UpdateEventAsync(Event eventItem);
        Task DeleteEventAsync(int eventId);
        Task RemoveUserFromEventAsync(string userId, int eventId);
    }
}

