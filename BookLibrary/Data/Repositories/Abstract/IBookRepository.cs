using BookLibrary.Models.Domain;

namespace BookLibrary.Data.Repositories.Abstract
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBorrowedBooks(Guid customerId);
    }
}
