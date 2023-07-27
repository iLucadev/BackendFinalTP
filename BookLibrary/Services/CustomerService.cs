using BookLibrary.Data.Repositories.Abstract;
using BookLibrary.Data.Repositories.Implementation;
using BookLibrary.Models.Domain;
using BookLibrary.Services.Abstract;

namespace BookLibrary.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;
        public CustomerService(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }
    
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAll();

        }
        public async Task<Customer?> GetCustomerById(Guid? customerId)
        {
            var customer = await _customerRepository.GetById(customerId);

            return customer ?? null;
        }
        public async Task CreateCustomer(Customer customer)
        {
            await _customerRepository.Insert(customer);
        }

        public async Task DeleteCustomer(Guid customerId)
        {
            await _customerRepository.Delete(customerId);
        }
        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.Update(customer);
        }

        public async Task<List<Book>> GetBorrowedBooks(Guid customerId)
        {
            var books = await _bookRepository.GetBorrowedBooks(customerId);
            return books;
        }

        public Task RenewBook(Guid bookId, Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task ReturnBook(Guid bookId, Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
