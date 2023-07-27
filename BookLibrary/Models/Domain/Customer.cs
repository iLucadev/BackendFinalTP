using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models.Domain
{
    public class Customer
    {
        [Key]
        [StringLength(36)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "First Name should be between 4 - 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Last Name should be between 4 - 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "number is too big. Check your input!")]
        [Phone]
        [Range(0, long.MaxValue, ErrorMessage = "Contact number should not contain characters")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(300, ErrorMessage = "Email is too big. 300 characters Max!")]
        public string Email { get; set; } = string.Empty;

        public ICollection<BookCustomer> BookCustomers { get; set; }

        public string FullName() => FirstName + " " + LastName;

        public Customer()
        {

        }
    }
}
