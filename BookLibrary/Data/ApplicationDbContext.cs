using BookLibrary.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
