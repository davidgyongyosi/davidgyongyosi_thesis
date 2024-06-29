using System;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Logic.Classes
{
    public class EventLogic : IEventLogic
    {
        private readonly IEventRepository _eventRepository;

        public EventLogic(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByUserIdAsync(string userId)
        {
            return await _eventRepository.GetEventsByUserIdAsync(userId);
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _eventRepository.GetEventByIdAsync(eventId);
        }

        public async Task CreateEventAsync(Event eventItem)
        {
            await _eventRepository.AddEventAsync(eventItem);
        }

        public async Task UpdateEventAsync(Event eventItem)
        {
            await _eventRepository.UpdateEventAsync(eventItem);
        }

        public async Task DeleteEventAsync(int eventId)
        {
            await _eventRepository.DeleteEventAsync(eventId);
        }

        public async Task UnattendEventAsync(string userId, int eventId)
        {
            await _eventRepository.RemoveUserFromEventAsync(userId, eventId);
        }
    }
}

