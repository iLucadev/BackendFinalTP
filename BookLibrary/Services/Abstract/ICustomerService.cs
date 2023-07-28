using BookLibrary.Models.Domain;

namespace BookLibrary.Services.Abstract
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(Guid customerId);
        Task CreateCustomer(Customer customerId);
        Task UpdateCustomer(Customer customerId);
        Task DeleteCustomer(Guid customerId);
        Task<List<Book>> GetBorrowedBooks(Guid customerId);
        Task ReturnBook(Guid bookId, Guid customerId);
        Task RenewBook(Guid bookId, Guid customerId);
    }
}
