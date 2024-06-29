using System;
namespace uninavigation_backend.Models
{
	public class Ar_content
	{
        public int Id { get; set; }
        public string ContentName { get; set; }
        public string Content { get; set; }
        public string RoomName { get; set; }
        public int Elevation { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}