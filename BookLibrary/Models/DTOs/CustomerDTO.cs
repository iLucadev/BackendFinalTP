using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookLibrary.Models.DTOs
{
    public class CustomerDTO
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "First Name should be between 4 - 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Last Name should be between 4 - 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "number is too big. Check your input!")]
        [Phone]
        [Range(0, Int64.MaxValue, ErrorMessage = "Contact number should not contain characters")]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(300, ErrorMessage = "Email is too big. 300 characters Max!")]
        public string Email { get; set; } = string.Empty;

        public string FullName() => FirstName + " " + LastName;

        public CustomerDTO()
        {

        }
    }
}
