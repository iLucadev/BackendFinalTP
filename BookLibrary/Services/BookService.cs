using BookLibrary.Data.Repositories.Abstract;
using BookLibrary.Data.Repositories.Implementation;
using BookLibrary.Models.Domain;
using BookLibrary.Services.Abstract;

namespace BookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public BookService(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAll();
        }
        public async Task<Book?> GetBookById(Guid? bookId)
        {
            var book = await _bookRepository.GetById(bookId);

            return book ?? null;
        }
        public async Task CreateBook(Book book)
        {
           await _bookRepository.Insert(book);
        }

        public async Task DeleteBook(Guid bookId)
        {
            await _bookRepository.Delete(bookId);
        }
        public async Task UpdateBook(Book book)
        {
            await _bookRepository.Update(book);
        }
        public async Task<Customer?> GetBorrower(Guid bookId)
        {
            var book = await _bookRepository.GetById(bookId);
            if (book == null)
            {
                return null;
            }

            var borrowerId = book.BookCustomers.FirstOrDefault()?.CustomerId;
            var borrower = await _customerRepository.GetById(borrowerId);

            return borrower ?? null;
        }
        public async Task<bool> IsAvailable(Guid bookId)
        {
            var book = await _bookRepository.GetById(bookId);
            if (book == null)
            {
                return true;
            }

            return book.BookCustomers.Count == 0;
        }
    }
}
