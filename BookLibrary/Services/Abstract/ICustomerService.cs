using BookLibrary.Models.Domain;

namespace BookLibrary.Services.Abstract
{
    public interface ICustomerService
    {
        Task<List<Book>> GetBorrowedBooks(Guid customerId);
        Task ReturnBook(Guid bookId, Guid customerId);
        Task RenewBook(Guid bookId, Guid customerId);
    }
}
