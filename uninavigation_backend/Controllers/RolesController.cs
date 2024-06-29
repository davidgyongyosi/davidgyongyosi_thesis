using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uninavigation_backend.Models;
using uninavigation_backend.Models.DTOs;

namespace uninavigation_backend.Controllers
{
    [Authorize(Roles = "Admin")]
	[ApiController]
	[Route("[controller]")]
	public class RolesController : ControllerBase
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<NavUser> _userManager;

		public RolesController(RoleManager<IdentityRole> roleManager, UserManager<NavUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO createRoleDTO)
		{
			if (string.IsNullOrEmpty(createRoleDTO.RoleName))
			{
				return BadRequest("Role name is required");
			}

			var roleExist = await _roleManager.RoleExistsAsync(createRoleDTO.RoleName);

			if (roleExist)
			{
				return BadRequest("Role already exist");
			}

			var roleResult = await _roleManager.CreateAsync(new IdentityRole(createRoleDTO.RoleName));

			if (roleResult.Succeeded)
			{
				return Ok(new { message = "Role Created Successfully" });
			}

			return BadRequest("Role creation failed");
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<RoleResponseDTO>>> GetRoles()
		{
			var roles = await _roleManager.Roles.Select(r => new RoleResponseDTO
			{
				Id = r.Id,
				Name = r.Name
			}).ToListAsync();

			return Ok(roles);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRole(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);

			if (role is null)
			{
				return NotFound("Role not found");
			}

			var result = await _roleManager.DeleteAsync(role);

			if (result.Succeeded)
			{
				return Ok(new { message = "Role Deleted Successfully" });
			}

			return BadRequest("Role deletion failed");
		}

		[HttpPost("assign")]
		public async Task<IActionResult> AssignRole([FromBody] RoleAssingDTO roleAssingDTO)
		{
			var user = await _userManager.FindByIdAsync(roleAssingDTO.UserId);

			if (user is null)
			{
				return NotFound("User not found.");
			}

            var role = await _roleManager.FindByIdAsync(roleAssingDTO.RoleId);

			if (role is null)
			{
				return NotFound("Role not found");
			}

            var rolesRemoved = await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));

            if (!rolesRemoved.Succeeded)
            {
                return BadRequest("Failed to remove existing roles.");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name!);

			if (result.Succeeded)
			{
				return Ok(new { message = "Role assigned successfully" });
			}

			var error = result.Errors.FirstOrDefault();
			return BadRequest(error!.Description);
		}

		[HttpGet("user/{userId}")]
		public async Task<IActionResult> UserRole(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if(user is null)
			{
                return NotFound("User not found.");
            }

			var result = await _userManager.GetRolesAsync(user);

			if(result is null)
			{
                return NotFound("Role not found");
            }

			return Ok(result);
		}
	}
}

