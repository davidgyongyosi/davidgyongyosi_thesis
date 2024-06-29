using System;
using Microsoft.EntityFrameworkCore;
using uninavigation_backend.Data;
using uninavigation_backend.Models;
using uninavigation_backend.Repositories.Interfaces;

namespace uninavigation_backend.Repositories.Classes
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByUserIdAsync(string userId)
        {
            return await _context.Events
                .Where(e => e.Participants.Any(p => p.User.Id == userId))
                .Include(e => e.Participants)
                    .ThenInclude(p => p.User)
                .ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task AddEventAsync(Event eventItem)
        {
            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event eventItem)
        {
            _context.Entry(eventItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var eventItem = await _context.Events.FindAsync(eventId);
            if (eventItem != null)
            {
                _context.Events.Remove(eventItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveUserFromEventAsync(string userId, int eventId)
        {
            var userEvent = await _context.UserEvents.FirstOrDefaultAsync(ue => ue.UserId == userId && ue.EventId == eventId);
            if (userEvent != null)
            {
                _context.UserEvents.Remove(userEvent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
