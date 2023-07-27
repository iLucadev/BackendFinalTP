using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models.Domain
{
    public class Book
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        public bool IsBorrowed { get; set; } = false;

        public ICollection<BookCustomer> BookCustomers { get; set; }

        public Book()
        {

        }
    }
}
