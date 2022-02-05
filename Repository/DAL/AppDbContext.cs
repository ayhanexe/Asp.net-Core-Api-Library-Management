using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
