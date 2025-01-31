using Microsoft.EntityFrameworkCore;
using WebApplicationCommand.Models;

namespace WebApplicationCommand.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Command> Commands => Set<Command>();
    }
}
