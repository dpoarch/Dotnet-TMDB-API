using Assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Data
{
    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<History> History { get; set; }
    }
}
