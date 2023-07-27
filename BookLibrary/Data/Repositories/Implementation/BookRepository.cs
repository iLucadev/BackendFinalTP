using BookLibrary.Data.Repositories.Abstract;
using BookLibrary.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.Repositories.Implementation
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Book>> GetBorrowedBooks(Guid customerId)
        {
            var books = await _context.Books
                .Where(b => b.BookCustomers.Any(bc => bc.CustomerId == customerId))
                .ToListAsync();

            return books;
        }
    }
}
