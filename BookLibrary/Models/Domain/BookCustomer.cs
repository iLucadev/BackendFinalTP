namespace BookLibrary.Models.Domain
{
    public class BookCustomer
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public BookCustomer()
        {

        }
    }
}
