using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models.Domain
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Title field is required.")]
        [StringLength(50, ErrorMessage = "The field must be 50 characters maximum.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author field is required.")]
        [StringLength(50, ErrorMessage = "The field must be 50 characters maximum.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN field is required.")]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "Insert a valid ISBN.")]
        public string ISBN { get; set; }

        public bool IsBorrowed { get; set; } = false;

        public ICollection<BookCustomer>? BookCustomers { get; set; }

        public Book()
        {

        }
    }
}
