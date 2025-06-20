using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
