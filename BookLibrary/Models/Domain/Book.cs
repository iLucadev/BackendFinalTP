using System.ComponentModel.DataAnnotations;

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
        public bool Available { get; set; } = true;

        public List<CustomerBook> Customer_Book { get; set; } = new List<CustomerBook>();

        public Book()
        {

        }
    }
}
