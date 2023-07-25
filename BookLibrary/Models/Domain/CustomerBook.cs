namespace BookLibrary.Models.Domain
{
    public class CustomerBook
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime Borrowed { get; set; } = DateTime.Now;

        public CustomerBook()
        {

        }
    }
}
