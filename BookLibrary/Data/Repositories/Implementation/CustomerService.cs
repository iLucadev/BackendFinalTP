using BookLibrary.Data.Repositories.Abstract;
using BookLibrary.Models;

namespace BookLibrary.Data.Repositories.Implementation
{
    public class CustomerService : ICustomerRepository
    {
        public readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> GetBorrowedCount(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
