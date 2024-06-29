using System;
using System.ComponentModel.DataAnnotations;

namespace uninavigation_backend.Models.DTOs
{
	public class CreateRoleDTO
	{
		[Required(ErrorMessage = "Role Name is required")]
		public string RoleName { get; set; } = null!;
	}

	public class RoleResponseDTO
	{
		public string? Id { get; set; }
		public string? Name { get; set; }
		public int TotalUsers { get; set; }
	}

	public class RoleAssingDTO
    {
		public string UserId { get; set; } = null!;
		public string RoleId { get; set; } = null!;
	}
}

