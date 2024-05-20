using EMSTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSTutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Campaign> campaigns { get; set; }
    }
}
