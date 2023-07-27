using BookLibrary.Models.Domain;

namespace BookLibrary.Services.Abstract
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(Guid? bookId);
        Task CreateBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Guid bookId);
        Task<Customer?> GetBorrower(Guid bookId);
        Task<bool> IsAvailable(Guid bookId);
    }
}
