using System;
namespace uninavigation_backend.Models.DTOs
{
    public class CreateEventDTO
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
    }

    public class EventListDTO
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EventLocationDTO Location { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public int ParticipantCount { get; set; }
    }

    public class EventDetailDTO
    {
        public int EventId { get; set; }
        public string? Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Location Location { get; set; }
        public string? Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public List<ParticipantDTO>? Participants { get; set; }
    }

    public class ParticipantDTO
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class UpdateEventDTO
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EventLocationDTO Location { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
    }

    public class AttendEventDTO
    {
        public string UserId { get; set; }
    }
}

