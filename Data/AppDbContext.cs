using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<Book> Book { get; set; }
    private DbSet<Author> Author { get; set; }
    private DbSet<Category> Category { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=library;User Id=postgres;Password=1209;");
        base.OnConfiguring(optionsBuilder);
    }
}