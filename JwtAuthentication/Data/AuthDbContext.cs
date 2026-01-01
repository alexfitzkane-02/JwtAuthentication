using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "e770e579-13a6-48ba-b8b5-039d477cdfb1";
            var writerRoleId = "a12d6d0a-42d8-46ea-a0b8-2f31b652f159";

            //Create Reader and Writer Roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                }
            };

            //Seed Roles to the Database
            builder.Entity<IdentityRole>().HasData(roles);

            //Create an Admin User
            var adminUserId = "eba99433-6f9a-40a3-b537-04fd164991ea";
            var adminConcurrencyStamp = "2d7a8921-a61b-4a42-a7af-a8ac12e89b31";
            var adminSecurityStamp = "4063c969-91f5-4a50-8cf0-da30d29457de";

            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                ConcurrencyStamp = adminConcurrencyStamp,
                SecurityStamp = adminSecurityStamp
            };

            //Set Admin password

            admin.PasswordHash = "AQAAAAIAAYagAAAAEPhkEVLlnz/KgclF1MEKvjZMKxnmNwGhSuxEuRDNeo4HJSHijhI+QaKDzxVTmHBsAw==";

            //Seed Admin User to the Database
            builder.Entity<IdentityUser>().HasData(admin);

            //Assign Admin User to Reader and Writer Roles
            var adminRoles = new List<IdentityUserRole<string>>
            {
                 new IdentityUserRole<string>
                    {
                        RoleId = readerRoleId,
                        UserId = adminUserId
                    },
                 new IdentityUserRole<string>
                    {
                        RoleId = writerRoleId,
                        UserId = adminUserId
                    }
            };

            //Seed Admin Roles to the Database
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
