using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uninavigation_backend.Data;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models;
using uninavigation_backend.Models.DTOs;
using uninavigation_backend.Models.RelationModels;

namespace uninavigation_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventLogic _eventLogic;
        private readonly INavUserLogic _userLogic;
        private readonly ApplicationDbContext _context;

        public EventsController(IEventLogic eventLogic, INavUserLogic userLogic, ApplicationDbContext context)
        {
            _eventLogic = eventLogic;
            _userLogic = userLogic;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<EventDetailDTO>> GetAllEventsAsync()
        {
            var events = await _eventLogic.GetAllEventsAsync();
            var eventDetailDtos = events.Select(e => new EventDetailDTO
            {
                EventId = e.EventId,
                Name = e.Name,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                Location = e.Location,
                Description = e.Description,
                Data = e.Data,
                ContentType = e.ContentType,
                Participants = e.Participants.Select(p => new ParticipantDTO
                {
                    UserId = p.User.Id,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName
                }).ToList()
            });

            return eventDetailDtos;
        }

        [HttpGet("user-events/{id}")]
        public async Task<IEnumerable<EventDetailDTO>> GetEventsForUser(string id)
        {
            var events = await _eventLogic.GetEventsByUserIdAsync(id);
            var userEventDtos = events.Select(e => new EventDetailDTO
            {
                EventId = e.EventId,
                Name = e.Name,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                Location = e.Location,
                Description = e.Description,
                Data = e.Data,
                ContentType = e.ContentType,
                Participants = e.Participants.Select(p => new ParticipantDTO
                {
                    UserId = p.User.Id,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName
                }).ToList()
            });

            return userEventDtos;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailDTO>> GetEvent(int id)
        {
            var eventItem = await _eventLogic.GetEventByIdAsync(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            var eventDetailDto = new EventDetailDTO
            {
                EventId = eventItem.EventId,
                Name = eventItem.Name,
                StartTime = eventItem.StartTime,
                EndTime = eventItem.EndTime,
                Location = eventItem.Location,
                Description = eventItem.Description,
                Data = eventItem.Data,
                ContentType = eventItem.ContentType,
                Participants = eventItem.Participants.Select(p => new ParticipantDTO
                {
                    UserId = p.User.Id,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName
                }).ToList()
            };

            return eventDetailDto;
        }


        [HttpPost]
        public async Task<ActionResult<EventDetailDTO>> PostEvent([FromForm]CreateEventDTO createEventDto)
        {
            var location = _context.Locations.Find(createEventDto.Location);

            var eventItem = new Event
            {
                Name = createEventDto.Name,
                StartTime = createEventDto.StartTime,
                EndTime = createEventDto.EndTime,
                Location = location,
                Description = createEventDto.Description,
                ContentType = createEventDto.Picture.ContentType,
                Data = await FileToByteArrayAsync(createEventDto.Picture)
            };

            await _eventLogic.CreateEventAsync(eventItem);

            var eventDetailDto = new EventDetailDTO
            {
                EventId = eventItem.EventId,
                Name = eventItem.Name,
                StartTime = eventItem.StartTime,
                EndTime = eventItem.EndTime,
                Location = eventItem.Location,
                Description = eventItem.Description,
                ContentType = eventItem.ContentType,
                Data = eventItem.Data,
                Participants = new List<ParticipantDTO>()
            };

            return CreatedAtAction("GetEvent", new { id = eventItem.EventId }, eventDetailDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, [FromForm]UpdateEventDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventItem = await _eventLogic.GetEventByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            eventItem.Name = updateDto.Name;
            eventItem.StartTime = updateDto.StartTime;
            eventItem.EndTime = updateDto.EndTime;
            eventItem.Location = new Location()
            {
                Id = updateDto.Location.Id,
                Name = updateDto.Location.Name
            };
            eventItem.Description = updateDto.Description;
            if (updateDto.Picture != null)
            {
                eventItem.ContentType = updateDto.Picture.ContentType;
                eventItem.Data = await FileToByteArrayAsync(updateDto.Picture);
            }

            try
            {
                await _eventLogic.UpdateEventAsync(eventItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await _eventLogic.GetEventByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            await _eventLogic.DeleteEventAsync(id);

            return NoContent();
        }

        private async Task<bool> EventExists(int id)
        {
            var eventItem = await _eventLogic.GetEventByIdAsync(id);
            return eventItem != null;
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> AttendEvent(int id, [FromBody] AttendEventDTO attendDto)
        {
            var eventItem = await _eventLogic.GetEventByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            // Assuming you have a method to get a User by their ID
            var user = await _userLogic.GetUserByIdAsync(attendDto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Check if user is already a participant
            if (eventItem.Participants.Any(p => p.UserId == user.Id))
            {
                return BadRequest("User is already attending this event");
            }

            // Add user to event's participants
            var userEvent = new UserEvent { User = user, Event = eventItem };
            eventItem.Participants.Add(userEvent);

            await _eventLogic.UpdateEventAsync(eventItem);

            return Ok();
        }

        [HttpDelete("{id}/unattend/{userId}")]
        public async Task<IActionResult> UnattendEvent(int id, string userId)
        {
            if (userId == null)
            {
                return Unauthorized();
            }

            var eventExists = await _eventLogic.GetEventByIdAsync(id);
            if (eventExists == null)
            {
                return NotFound("Event not found.");
            }

            await _eventLogic.UnattendEventAsync(userId, id);
            return NoContent();
        }

        private async Task<byte[]> FileToByteArrayAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }

}

