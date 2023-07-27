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
        public DbSet<BookCustomer> BookCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCustomer>()
                .HasKey(bc => new { bc.BookId, bc.CustomerId });
            modelBuilder.Entity<BookCustomer>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCustomers)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCustomer>()
                .HasOne(bc => bc.Customer)
                .WithMany(c => c.BookCustomers)
                .HasForeignKey(bc => bc.CustomerId);

        }
    }
}
