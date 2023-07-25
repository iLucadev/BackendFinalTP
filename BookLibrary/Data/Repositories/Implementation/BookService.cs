using BookLibrary.Data.Repositories.Abstract;
using BookLibrary.Models.Domain;

namespace BookLibrary.Data.Repositories.Implementation
{
    public class BookService : IBookRepository
    {
        public Task<List<Book>> GetBorrowedBooks(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
