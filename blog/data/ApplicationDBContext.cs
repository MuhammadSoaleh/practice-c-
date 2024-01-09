using blogs.Models;
using Microsoft.EntityFrameworkCore;

namespace blogs.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<blogg> bloggs { get; set; }


    }
}
