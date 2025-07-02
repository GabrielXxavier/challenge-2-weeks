using Domain.Models;
using Microsoft.EntityFrameworkCore;



namespace BookService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
