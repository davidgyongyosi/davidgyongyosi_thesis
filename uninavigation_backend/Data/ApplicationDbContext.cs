using System;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using uninavigation_backend.Models;
using uninavigation_backend.Models.RelationModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace uninavigation_backend.Data
{
	public class ApplicationDbContext : IdentityDbContext<NavUser>
	{
        public DbSet<NavUser> NavUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ar_content> Ar_Contents { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "User", NormalizedName = "USER" },
                new { Id = "3", Name = "Student", NormalizedName = "STUDENT"},
                new { Id = "4", Name = "Visitor", NormalizedName = "VISITOR" }
                );

            PasswordHasher<NavUser> ph = new PasswordHasher<NavUser>();
            var superuserId = Guid.NewGuid().ToString();

            NavUser superuser = new NavUser
            {
                Id = superuserId,
                Email = "admin@admin.adm",
                EmailConfirmed = true,
                UserName = "superuser",
                FirstName = "Super",
                LastName = "User",
                NormalizedUserName = "SUPERUSER"
            };
            superuser.PasswordHash = ph.HashPassword(superuser, "Passw0rd!");
            builder.Entity<NavUser>().HasData(superuser);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new { UserId = superuserId, RoleId = "1" }
            );

            builder.Entity<UserEvent>()
            .HasKey(ue => new { ue.UserId, ue.EventId });

            builder.Entity<UserEvent>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.Events)
                .HasForeignKey(ue => ue.UserId);

            builder.Entity<UserEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(ue => ue.EventId);

            base.OnModelCreating(builder);
        }
    }
}

