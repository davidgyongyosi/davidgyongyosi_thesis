using System;
using uninavigation_backend.Models.RelationModels;

namespace uninavigation_backend.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Location Location { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public virtual ICollection<UserEvent> Participants { get; set; }
    }
}

