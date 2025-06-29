using Microsoft.EntityFrameworkCore;
using BookNestAPI.Models;

namespace BookNestAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
    }
}
