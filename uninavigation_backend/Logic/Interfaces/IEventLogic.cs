using System;
using uninavigation_backend.Models;

namespace uninavigation_backend.Logic.Interfaces
{
    public interface IEventLogic
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetEventsByUserIdAsync(string userId);
        Task CreateEventAsync(Event eventItem);
        Task UpdateEventAsync(Event eventItem);
        Task DeleteEventAsync(int eventId);
        Task UnattendEventAsync(string userId, int eventId);
    }
}

