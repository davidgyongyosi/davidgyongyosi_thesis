using System;
using System.ComponentModel.DataAnnotations;

namespace uninavigation_backend.Models.DTOs
{

    public class UserDetailDTO
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public string[] Roles { get; set; }
        public List<UserEventDTO> Events { get; set; }
    }

    public class UserEventDTO
    {
        public int EventId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateUserDTO
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }

    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public List<string>? Roles { get; set; }
    }
}