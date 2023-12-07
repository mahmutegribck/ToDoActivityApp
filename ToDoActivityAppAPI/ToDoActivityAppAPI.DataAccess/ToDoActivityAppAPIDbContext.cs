using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.DataAccess
{
    public class ToDoActivityAppAPIDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ToDoActivityAppAPIDbContext(DbContextOptions<ToDoActivityAppAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactReply> ContactReplies { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<AdminActivity> AdminActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);

            //builder.Entity<Activity>().HasOne(u => u.ApplicationUser).WithMany(a => a.Activities).HasForeignKey(u => u.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Image>().HasOne(u => u.Activity).WithMany(a => a.Images).OnDelete(DeleteBehavior.NoAction);
            //builder.Entity<Activity>().HasMany(a => a.Images).WithOne(i => i.Activity).HasForeignKey(i => i.ActivityId).OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<Activity>().HasOne(a => a.ApplicationUser).WithMany(u => u.Activities).HasForeignKey(a => a.ApplicationUserId);

            //builder.Entity<Image>().HasOne(i => i.ApplicationUser).WithMany(u => u.Images).HasForeignKey(i => i.ApplicationUserId);
        }

        private void SeedUsers(ModelBuilder builder)
        {

            ApplicationUser applicationUser = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Name = "Admin",
                Surname = "Admin",
                UserName = "Admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN",
                SecurityStamp = Guid.NewGuid().ToString()
                


            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            applicationUser.PasswordHash = passwordHasher.HashPassword(applicationUser, "Admin*123");

            builder.Entity<ApplicationUser>().HasData(applicationUser);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole()
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new ApplicationRole()
                {
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "User"
                });
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}
