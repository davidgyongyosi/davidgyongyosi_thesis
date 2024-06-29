using System;
namespace uninavigation_backend.Models.DTOs
{
	public class LocationDTO
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public Ar_content ar_Content { get; set; }
    }

    public class EventLocationDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

