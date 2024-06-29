using System;
namespace uninavigation_backend.Models.RelationModels
{
    public class UserEvent
    {
        public string UserId { get; set; }
        public virtual NavUser User { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

