using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User>Users { get; set; }

        public DbSet<Section> Sections { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
        }
    }
}