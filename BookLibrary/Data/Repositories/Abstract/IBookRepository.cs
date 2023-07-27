using BookLibrary.Models.Domain;

namespace BookLibrary.Data.Repositories.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetBorrowedBooks(Guid customerId);
    }
}
