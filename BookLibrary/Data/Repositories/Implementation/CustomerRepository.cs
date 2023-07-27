using BookLibrary.Data.Repositories.Abstract;
using BookLibrary.Models.Domain;

namespace BookLibrary.Data.Repositories.Implementation
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }
    }
}
