using System;
using uninavigation_backend.Models.RelationModels;

namespace uninavigation_backend.Models
{
	public class Location
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public virtual Ar_content ar_Content { get; set; }
	}
}

