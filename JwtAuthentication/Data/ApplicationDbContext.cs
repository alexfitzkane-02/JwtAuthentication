using JwtAuthentication.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            {

            }
        }


        public DbSet<Cars> Cars { get; set; }

    }
}
