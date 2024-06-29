using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using uninavigation_backend.Models;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models.DTOs;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;

namespace uninavigation_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<NavUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<NavUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
                };
                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("UniNavigationTitkosKodAmiNagyonHosszu"));
                var token = new JwtSecurityToken(
                 issuer: "http://www.security.org", audience: "http://www.security.org",
                 claims: claim, expires: DateTime.Now.AddMinutes(60),
                 signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                var userRoles = await _userManager.GetRolesAsync(user);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    role = userRoles
                });
            }
            return Unauthorized();
        }

        [HttpPut("register")]
        public async Task<IActionResult> InsertUser([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new NavUser
            {
                Email = model.Email,
                UserName = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            if (model.Roles is null)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                foreach (var role in model.Roles)
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            return Ok(new AuthResponseDTO
            {
                IsSuccess = true,
                Message = "Account Created Successfully!"
            });
        }

        [HttpGet("detail")]
        public async Task<ActionResult<UserDetailDTO>> GetUserDetail()
        {
            var currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByNameAsync(currentUser!);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(new UserDetailDTO
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = _userManager.GetRolesAsync(user).Result.ToArray(),
                Picture = user.Picture
            });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMyself()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.UserName == this.User.Identity.Name);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { message = "User Deleted Successfully" });
            }

            return BadRequest("User deletion failed");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == userId);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { message = "User Deleted Successfully" });
            }

            return BadRequest("User deletion failed");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userManager.Users.FirstOrDefault(t => t.Id == model.UserID);

            if (user is null)
            {
                return NotFound();
            }

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Picture = model.Picture;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { message = "User Updated Successfully" });
            }

            return BadRequest("User data update failed");
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDetailDTO>>> GetUsers()
        {
            var users = await _userManager.Users
                .Select(u => new UserDetailDTO
                {
                    UserId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Picture = u.Picture,
                    Roles = Array.Empty<string>()
                }).ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(_userManager.Users.FirstOrDefault(u => u.Id == user.UserId));
                user.Roles = roles.ToArray();
            }


            return Ok(users);
        }

    }
}