using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using uninavigation_backend.Models.RelationModels;

namespace uninavigation_backend.Models
{
    public class NavUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Picture { get; set; }

        public virtual ICollection<UserEvent> Events { get; set; }
    }
}

