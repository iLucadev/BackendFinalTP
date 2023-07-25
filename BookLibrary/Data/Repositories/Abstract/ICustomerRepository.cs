using BookLibrary.Models;

namespace BookLibrary.Data.Repositories.Abstract
{
    public interface ICustomerRepository
    {
        Task<int> GetBorrowedCount(Guid customerId);
    }
}
